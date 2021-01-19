## MOM 
# Development Guide
<br>

<center> R&D team </center>
<br>

<center> v.1.0.0. </center>
<br>

<center> yoon, lee </center>   
<br><br>

<center> copyright@ FormationLabs </center>   
<br>   

---
## Document Information

|Document No|Description|
|-|-|
|D325|Describe how to develop on mom framework.
<br>   

## Revision History
|Version|Modified Date|Modifier|Desciption|
|-|-|-|-|
|1.0.0.|2021-01-15|yoon, lee|Write first version|

<br>   

---

## Index
<br>

1. ### [Develop UI](#1)
   1. #### [Design UI]()
   2. #### [Implement View]()
2. ### [Develop Service](#2)
   1. #### [Set Message]()
   2. #### [Implement Test Code]()
   3. #### [Implement Contoroller]()
   4. #### [Implement Rule]()
3. ### [Test Source](#3)
   1. #### [Execute Unit Test]()
   2. #### [Inspect Static Code]()
   3. #### [Refactoring]()
4. ### [Merge Source](#4)
   1. #### [Avoid Source Conflict]()
   2. #### [Request Merge]()

<br>

---
<div id='1'/>

1. ### **Develop UI**

    > 빠른 이해를 위해 Sample 예제를 통해 UI 개발 과정을 소개 합니다.

   - View 파일 생성
      - razor 파일
      - cs 파일

   1. #### Design UI

      - Filter Layout 배치
      - Contents Layout 배치
        - Layout 구조 및 비율 설정
      - Component 배치

   1. #### Implement View

      - Component ref-Id 속성 부여    
      - Event 처리
      - Service 요청
        - 쿼리 조회 요청
        - 동적 Entity CUD 처리 요청 
        - Business Logic 처리 요청
      - Messge 수신 처리
        - Notify Box 사용
        - Message Box 사용
        - Error Message Box `(to develop)`
      - [How to use Common Component]()

   1. #### Example Source

      ```html
      //.razor
      ```
      ```c#
      //.cs
      ```
<br>

---
<div id='2'/>

1. ### **Develop Service**
   1. #### Implement Test Code
      - 성공 처리 테스트
      - 실패 처리 테스트
      - Null 테스트
   1. #### Implement Contoroller
      - Controller 선언
      - Post Method 구현
      - Swagger 확인
   1. #### Implement Rule
      - Rule 선언
      - 시스템 변수 설정
         - System Time (Db Time)
         - TID
         - Modifier
      - Message 유효성 검증
         - `MessageSet.ValidateKeystring location, string key)` : 메시지 내 위치 (Header, Body, Reply)에 지정한 Key의 속성이 존재하는지 확인
         - `MessageSet.ValidateValue(string location, string key)` : 메시지 내 위치 (Header, Body, Reply)에 지정한 Key의 값이 존재하는지 확인
      - Rule 실행
         1. Select stored entities
         2. Update properties
            - `List<dictionary<string,object>>.CopyToEntity()` : 지정한 속성만 stored entity에 복사

         3. Upsert entities
      - Rule 결과
         - Reply Code 정의
            
            [공통 코드 정의](../3%20설계/공통%20코드%20정의.md)
         - 성공 처리
            - Entity 반환
            - Message 반환
         - 실패 처리
         - 에러 처리
      - 타 서비스 이벤트 연결
      - 공통 Rule 등록
         ```c#
         public class ExtensionMethod
         {
            public int TrackInAssy(this Lot lot, DbCotext dbCon, LotId[] lotlist ...)
            {}     

         }
         ```
   1. #### 동적 Entity CUD Rule 사용
   1. #### Example Source
      ```c#
      // controller
      ```
      ```c#
      // rule
      ```
<br>

---
<div id='3'/>

3. ### **Test Source**
   1. #### Execute Unit Test

      생성한 테스트 코드를 실행하여 코드에 문제가 없는지 확인 합니다.
   2. #### Inspect Static Code

      Sonarrint를 이용하여 로컬 환경에서 정적 코드 검사를 수행합니다.
      > ! CI 과정 중 코드 품질 규칙을 통과하지 못하면 배포 이미지 생성이 불가합니다. 
   3. #### Refactoring

      [Sonarrint 검사 결과별 해결방안]()
<br>

---
<div id='4'/>

4. ### **Merge Source**
   1. #### Avoid Source Conflict
      > ! 충돌을 방지하기 위해 병합 대상이 되는 소스의 최신 버전과 동기화 합니다.
      
      `git pull [-remote] [-branch]`

      출돌이 발생할 경우, 로컬에서 해당 충돌을 해결한 이후 다시 commit 후 병합 요청 합니다.
   2. #### Request Merge

      1. push 개인 작업 branch
      2. Gitlab Site 접속 
         - Https://10.10.91.117:0000/aaaa
         - Request Merge
            - Check, Delete 개인 작업 branch
            - Check, Squash commit
<br>

---
