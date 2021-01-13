# Index
## [로그인](#로그인-기능-설계)
## [사이트변경]()
## [다국어](#다국어-기능-설계)

---

## 로그인 기능 설계
> MOM 로그인 정보의 유지는 아래와 같은 이유로 Browser 단위로 정보가 저장되는 Local storage를 사용한다. (Tab을 추가하거나 브라우저를 재 시작할 경우, 로그인 필요 없음)
- SSO 연동을 통한 로그인 정책
- ??

### 비즈니스 로직
  - Activity Diagram
    ::: mermaid
    graph TB
        subgraph Service
        b1[계정존재확인]-->b2{계정 존재?}
        b2-->|Yes| b3{계정잠김확인}
        b3-->|No| b4{비밀번호확인}
        b4-->|No|b5[LogIn Retry 카운트 증가]
        b4-->|Yes|b6[LogIn 처리]
        b6-->b7[권한있는 메뉴 리스트 반환]
        end
        subgraph UI
        a1[로그인클릭]-->a2[로그인PC 정보 수집]
        a2-->a3[비밀번호 암호화]
        a3-->a4[로그인 요청]
        a5[로그인실패]
        a6[계정 정보 및 비밀번호 저장]
        a6-->a7[메뉴 구성]
        end
        a4--msg-login-->b1
        b2 --No <br/> msg-loginfail--> a5
        b3--Yes <br/> msg-loginfail--> a5
        b5--msg-loginfail-->a5
        b7--msg-loginsuccess-->a6
    :::



### UI 설계
- **Design**   
    ![](../../wwwroot/img/login-2021-01-08-13-31-03.png)

- **설명**

    |항목|설명|컴포넌트|
    |-|-|-|-|
    |Id|사용자 Id (사번)|textbox|
    |Password|사용자 비밀번호|textbox|
    |Factory|사업장|dropdown|
    |Language|사용자 언어|dropdown|
       
 
- **Event**
 
    |순번|항목|설명|Message Id|UI Logic|
    |-|-|-|-|-|
    |1|Factory Binding|팩토리 코드 바인딩|[msg-factory](#msg-factory) |팩토리 코드 요청 및 바인딩|
    |2|Language Binding|시스템 언어 코드 바인딩|[msg-language](#msg-language)  |시스템 언어 코드 요청 및 바인딩|
    |3|Passwor Validation|비밀번호 유효성검증|  |입력한 비밀번호가 정책에 맞는지 즉시 검증|
    |4|Login Click|로그인 클릭 이벤트|[msg-login](#msg-login) |로그인 서비스 요청|

- **Message**
  1. common header
        ```json
        {
            "Header" : {
                "MessageName" : "LogIn",
                "CommunicationType" : "Request",
                "SiteId" : "", //선택한 Site Id
                "UserId" : "", //입력한 User Id
                "SourceSystem" : "MOM",
                "TargetSystem" : "OIX",
                "SourceUrl" : "0.0.0.0", //로컬 Ip 주소
                "TargetUrl" : "http://0.0.0.0:00/api/login",
                "SourceTopic" : "",
                "TargetTopic" : "OIX",
                "Tid" : "", //guid
                "TimeStamp" : "", //yyyy-MM-dd HH:mm:ss.fff
                "Language" : "", //선택한 Language Id
                "Encoding" : "", //default : null
                "SecretToken" : "" //jwt
            },
            "Body": [...],
            "Reply" : {...}
            }
        ```
  2. ### msg-factory
        ```json
        {
            "Header" : {
                "MessageName" : "ExecuteQuery",
                ...},
            "Body": [
                {"SqlId" : "GetFactoryCode"}, // 쿼리 Id
                {"SqlCondition":"Where Is Usable = 'Y'"} // Sql 조건문
                ],
            "Reply" : {...}
            }
        ```
  3. ### msg-language
        ```json
        {
            "Header" : {
                "MessageName" : "ExecuteQuery",
                ...},
            "Body": [
                {"SqlId" : "GetLanguageCode"}, // 쿼리 Id
                {"SqlCondition":"Where Is Usable = 'Y'"} // Sql 조건문
                ],
            "Reply" : {...}
            }
        ```
  4. ### msg-login
        ```json
        {
            "Header" : {...},
            "Body": [
                {"password" : "alksdfjeiwjaksdjf"}, //sha-256 type. 비밀번호
                {"macaddress":""}, // 맥어드레스            
                {"uiversion":"1.1.7"} // UI Version 정보
                ],
            "Reply" : {...}
            }
        ```

### Service 설계


- **비즈니스 로직 (Sequence Diagram)**
    ::: mermaid
    sequenceDiagram
        participant UI
        participant Controller
        participant Service
        UI->> Controller: Login 요청 메시지        
        Note right of Controller: Rational thoughts <br/>prevail!
        Controller-->> Service: CRUD
        Service->>Controller: Login 처리 결과
        Controller-->>UI: LogIn 응답 메시지
    :::

---
 

## 다국어 기능 설계
<br/>

> 다국어 지원 범위는 Syncfusion Blazor 컴포넌트 영역과 비 컴포넌트 영역으로 구분하여 적용한다.
1. 컴포넌트 영역
   - 컴포넌트에서 제공하는 Default Message 및 Label등의 이름 `(ex. Placeholder:"Choose Date"/"날짜를 선택하세요")`
   - Syncfusion에서 제공하는 resx 파일을 사용하여 다국어 처리한다. `(DB Data를 통하여 관리하기엔 Data의 양과 처리 영역이 너무 많음)`
2. 비 컴포넌트 영역
   - Label 등 컴포넌트가 아닌 Html Markup을 사용하여 디자인한 Element 등
   DB에 저장된 다국어 정보 + 번역 기능을 통해 다국어 처리한다.
<br/>

### **1. 컴포넌트 영역**

- **참고**   
  - [Syncfusion Localization 참고 링크](https://blazor.syncfusion.com/documentation/common/localization/)   
  - [Syncfusion Localization GitHub](https://github.com/syncfusion/blazor-locale)

### **2. 비 컴포넌트 영역**
- **Activity Diagram**
    ::: mermaid
    graph TB
        subgraph Service
        b1[b1.언어Data 조회]-->b2[b2.언어 Data 반환]
        end
        subgraph UI
        a1[a1.언어선택]-->a2[a2.언어Data 요청]
        a3[a3.Data 쿠키 저장] -->a4[a4.null Data 번역 api로 생성]
        end
        a2--msg-changeLanguage-->b1
        b2--msg-languageData-->a3              
    :::    

    |Activity|Lync|Description|
    |-|-|-|
    |a1.언어선택|[디자인설계](#UI-UX-Design)|- 로그인 메뉴에서 시스템 언어 선택 <br/>- Top 메뉴에서 시스템 언어 변경|
    |a2.언어 Data 요청|[msg-changeLanguage](#msg-changeLanguage)|시스템 언어 Data 요청|
    |b1.언어 Data 조회|[query-getLanguage](#Query-Design)|Query Service를 이용하여 시스템 언어 Data 조회|
    |b2.언어 Data 반환|[msg-languageData](#msg-languageData)|시스템 언어 Data 반환|
    |a3.Data 쿠키 저장]|[클래스설계](#UI-Class-Design)|- 시스템 언어 브라우저 쿠키에 저장 <br/>- UI, Message 별로 별도 저장|
    |a4.null 번역 API로 생성|-|시스템 Data가 없는 경우, 번역 API 호출하여 대체|

<br/>

- **Message**
  1. common header
        ```json
        {
            "Header" : {
                "MessageName" : "ChangeLanguage",
                "CommunicationType" : "Request",
                "SiteId" : "", //선택한 Site Id
                "UserId" : "", //입력한 User Id
                "SourceSystem" : "MOM",
                "TargetSystem" : "OIX",
                "SourceUrl" : "0.0.0.0", //로컬 Ip 주소
                "TargetUrl" : "http://0.0.0.0:00/api/login",
                "SourceTopic" : "",
                "TargetTopic" : "OIX",
                "Tid" : "", //guid
                "TimeStamp" : "", //yyyy-MM-dd HH:mm:ss.fff
                "Language" : "", //선택한 Language Id
                "Encoding" : "", //default : null
                "SecretToken" : "" //jwt
            },
            "Body": [...],
            "Reply" : {...}
            }
        ```
  2. ### msg-changeLanguage
        ```json
        {
            "Header" : {...},
            "Body": [
                {"Language" : "kr"}, // 선택한 언어                
                ],
            "Reply" : {...}
            }
        ```
  3. ### msg-languageData
        ```json
        {
            "Header" : {...},
            "Body": [
                {"Language" : "kr"}, // 선택한 언어                
                {"LanguageData":[
                    "FACTORY":"공장",
                    "MATERIAL":"자재",
                    ...
                ]},
                ],
            "Reply" : {"ISSUCCESS":"Y",
                        ....}
            }
        ```

- ### **UI UX Design**   
  ![](../../wwwroot/img/uifw-2021-01-06-15-11-30.png)
  - 선택된 언어의 국기 표시
  - 클릭했을 경우 선택할 수 있는 언어와 해당 국기 표시
  - 선택 시, 선택한 언어 Data 요청 및 변경

- ### **UI Class Design**
    
    ::: mermaid
    classDiagram
        ILocalization <|.. FLLabel
        ILocalization <|.. FLGrid
        ILocalization <|.. FLButton
        ILocalization <|.. FLMenu
        ILocalization <|.. FLDropDown
        FLLabel <.. LanguageService
        FLGrid <.. LanguageService
        FLButton <.. LanguageService
        FLMenu <.. LanguageService
        FLDropDown <.. LanguageService
        class ILocalization
        ILocalization : +string key
        ILocalization : +string DisplayName
        ILocalization : +GetDisplayName(string language, string key)
        class FLLabel
        class FLGrid
        class FLButton
        class FLMenu
        class FLDropDown
        class LanguageService
        LanguageService : +FindDisplayName(stringt factoryId, string language,string key)
        LanguageService : +SaveLanguageToCookie

    :::

    |항목|설명|
    |-|-|
    |ILocalization|다국어 처리를 위한 속성 및 함수의 규약|
    |FL[컴포넌트]|- 사용자 공통 컴포넌트 <br> - DisplayName 속성의 getter에서 GetDisplayName 함수를 호출 <br>- GetDisplayName 함수는 LanguageService를 사용|
    |LanguageService|- 쿠키에 저장된 언어 Data에서 공통 컴포넌트 key에 해당하는 언어 data를 반환 <br/> - Service 로부터 받은 언어 Data Cookie에 저장|   
<br/>    

- ### **Query Design**
```sql
select 
LANGUAGECODEID ,              //Key
CODETYPE ,                    //UI, MESSAGE
CODESUBTYPE ,                 //Grid, DropDown
LANGUAGECODEDATA              //Display Name
from FOM_MULTILANGUAGE fm
where SITEID = @siteId
and ISUSABLE = "Y"
and [LANGUAGE] = @language
```

- **Data Model**   
  언어 분류를 위한 코드의 사용은 ISO 639-1에 정의된 언어 표기를 따른다. [ISO 639-1 언어 코드 참고 링크](https://ko.wikipedia.org/wiki/ISO_639-1_%EC%BD%94%EB%93%9C_%EB%AA%A9%EB%A1%9D)

    |언어|코드|
    |-|-|
    |한국어|ko|
    |영어|en|
    |중국어|ko|
    |일본어|ja|
    
    |ENUMCLASSID|ENUMDEFINITIONiD|ENUMDEFINITIONNAME|ISDEFAULT|
    |-|-|-|-|
    |Languages|ko|Korean|Y|    
    |Languages|en|English|N|
    |Languages|zh|China|N|

---