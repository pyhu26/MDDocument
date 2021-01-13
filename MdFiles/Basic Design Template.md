# Title
<br>
<center> team </center>
<center> author </center>   
<br><br>   
<center> copyright@ FormationLabs </center>   
<br>   

---

## Index
<br>

### [Design Subject A]()
### [Design Subject B]()
---

### **Design Subject A**

### Detail Design
> MOM 로그인 정보의 유지는 Browser 단위로 정보가 저장되는 Local storage를 사용한다.   
> Browser Tab을 추가하거나 재 시작할 경우, 로그인 필요 없음
  
1. ### Logic Flow Design
   ```mermaid
    graph TB
        subgraph Service
        b1{b1.계정존재확인}-->|Yes| b2{b2.계정잠김확인}
        b2-->|No| b3{b3.비밀번호확인}
        b3-->|No|b4[b4.LogIn Retry 카운트 증가]
        b3-->|Yes|b5[b5.LogIn 처리]
        b5-->b6[b6.권한있는 메뉴 리스트 반환]
        end
        subgraph UI
        a1[a1.로그인클릭]-->a2[a2.로그인PC 정보 수집]
        a2-->a3[a3.비밀번호 암호화]
        a3-->a4[a4.로그인 요청]
        a5[a5.로그인실패]
        a6[a6.계정 정보 및 비밀번호 저장]
        a6-->a7[a7.메뉴 구성]
        end
        a4--msg-login-->b1
        b1 --No <br/> msg-loginfail--> a5
        b3--Yes <br/> msg-loginfail--> a5
        b5--msg-loginfail-->a5
        b7--msg-loginsuccess-->a6
    ```
    |Activity|Description|
    |-|-|
    |a1.로그인클릭||
    |a2.로그인PC 정보 수집||
    |a3.비밀번호 암호화||
    |a4.로그인요청||
    |a5.로그인실패||
    |a6.계정 정보 및 비밀번호 저장||
    |a7.메뉴 구성||
    |b1.계정 존재 확인||
    |b2.계정 잠김 확인||
    |b3.비밀번호 확인||
    |b4.LogIn Retry 카운트 증가||
    |b4.비밀번호 확인||
    |||
    |||

2. ### UI UX Design
3. ### UI Class Design
4. ### Message Design
5. ### Service Class Design
6. ### Query Design
7. ### Data Design

---

### **Design Subject B**

### Detail Design

1. ### Logic Flow Design
2. ### UI UX Design
3. ### UI Class Design
4. ### Message Design
5. ### Service Class Design
6. ### Query Design
7. ### Data Design