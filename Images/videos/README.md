# QA Videos

QA 포트폴리오의 버그 재현 및 수정 후 재검증 영상을 정리합니다.

## Folder Structure

```text
videos/
├── Before/
├── After/
└── 04-resolution-setting-fail.mp4
```

- `Before/` : 수정 전 버그 재현 영상
- `After/` : 수정 후 동일 조건 재검증 영상
- `04-resolution-setting-fail.mp4` : 아직 해결되지 않은 해상도 설정 / UI 레이아웃 문제 재현 영상

## Standalone FAIL Evidence

### BUG-UI-01 — 해상도 변경 시 UI 레이아웃 깨짐

- Status: **FAIL**
- Expected: 해상도 변경 후에도 UI 위치와 크기가 정상 유지
- Actual: 해상도 설정 변경 후 일부 UI 레이아웃이 깨지거나 의도한 화면 배치가 유지되지 않음
- Video: [해상도 설정 FAIL 영상 보기](./04-resolution-setting-fail.mp4)
- Bug Report: [BUG-UI-01 확인](../../Docs/Bug-Reports.md#bug-ui-01--해상도-변경-시-ui-레이아웃-깨짐)

## Before / After Evidence

- [Before 영상 폴더](./Before/)
- [After 영상 폴더](./After/)
