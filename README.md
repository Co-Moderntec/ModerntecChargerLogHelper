# ModerntecChargerLogHelper
![Discussions](https://img.shields.io/badge/.NET_Core-v3.1-brightgreen)
![Discussions](https://img.shields.io/badge/Fody-v6.5.2-brightgreen)
![Discussions](https://img.shields.io/badge/Costura.Fody-v5.3.0-brightgreen)

`C:\ModerntecChargerLogHelper` 디렉토리에 있는 모든 폴더내의 특정 zip 파일을 압축 해제하여
특정 파일의 확장자 `.log-*` 를 대상으로 파일 utf-8 인코딩 후 모든 라인을 읽어 `StreamWriter` 를 이용해
`C:\ModerntecChargerLogHelper\total_merge.log` 에 대상의 파일들의 txt 를 한 파일로 묶음

- 압축해제는 [System.IO.Compression](https://docs.microsoft.com/ko-kr/dotnet/api/system.io.compression?view=net-5.0) 를 이용함
