## 다국어 기능 설계

> 리소스 정적 파일에 다국어 정보를 저장한 후 브라우저 쿠키에 갱신하는 방법으로 우선 구현 후 (msdn, web, syncfusion 권장 방식)
> DB에 저장된 다국어 정보를 바로 브라우저 쿠키에 갱신하는 방법으로 성능 테스트 진행 후, 방식 변경 검토

### 작업 순서
1. resx 파일에 언어별 다국어 정보를 key:value 형태로 작성
2. resx 파일의 정보를 Browser cookie에 저장
3. 언어 변경 시, 선택한 언어의 .resx 파일을 읽어서 Browser cookie refresh
4. resx 파일 대신 DB에서 읽어와서 Memory로 처리하고 Rendering 하는 방식과 성능 비교하고 차이 없으면 Memory 방식으로 대체 

[Syncfusion Localization 참고 링크](https://blazor.syncfusion.com/documentation/common/localization/)

### UI
- 선택된 언어의 국기 표시
- 클릭했을 경우 선택할 수 있는 언어와 해당 국기 표시

![](../../wwwroot/img/uifw-2021-01-06-15-11-30.png)