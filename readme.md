# Document Admin Guid
> 본 문서는 마크다운 문서를 작성하기 위한 작업환경의 세팅 방법과 마크다운 작성법에 대한 내용을 포함하고 있다.   
> Markdown Syntax에 대한 기준은 아래 버전을 준수한다.
- Markdown 0.0.0
- Mermaid 0.0.0

## **1. 작업환경 구축**
### **1.1 작업환경 Tool**
Visial Code 설치 후 Extenstion Tab으로 이동해서 아래 Plugin 을 설치한다.
- Visual Code
- (plugin) Markdown All In One (3.4.0)
- (plugin) Markdown Past (0.12.3)
- (plugin) Markdown Preview Mermaid (1.9.1)
  
  버전은 준수하지 않아도 상관 없음

### **1.2. Image 저장 경로 변경**
- setting open `(ctrl + ,)`
- `Extension > Markdown Past` 로 이동
- `소스의 경로 + \wwwroot\img` 로 변경
![](../wwwroot/img/dag-2021-01-13-10-54-53.png)


## **2. 마크다운 문서 작성법**
기본적인 작성법은 아래 참고 사이트를 확인 바랍니다.
- [Markdown Syntax](https://www.markdownguide.org/basic-syntax/)
- [Mermaid Syntax](https://mermaid-js.github.io/mermaid/#/)

### 2.1. Imgae 붙여넣기
마크다운 문서에서 Image는 별도 저장 후 링크를 통한 형태로 지원되기 때문에 일반적인 문서 편집 방식과는 차이가 있다. 

1. 붙여넣기 할 Image 캡쳐 (on clipboard)
1. ctrl + alt + v
1. 경로 확인
1. 현재 시간을 Default 파일명 환경설정에 적용한 경로로 Image가 복사됩니다.
1. 모든 Image가 한군데에 저장되기 때문에 파일 중복을 피하기 위해 작성하시는 문서의 약어를 prefix를 넣어줍니다.   
<br/>

   ![](../wwwroot/img/dag-2021-01-13-11-05-08.png)
<br/>

   ![](../wwwroot/img/dag-2021-01-13-11-06-00.png)