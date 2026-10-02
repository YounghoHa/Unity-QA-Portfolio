# QA Videos

QA 포트폴리오의 버그 재현 및 수정 후 재검증 영상을 정리합니다.

## Folder Structure

```text
videos/
├── Before/
├── After/
└── README.md
```

- `Before/` : 수정 전 버그 재현 영상
- `After/` : 수정 후 동일 조건 재검증 영상
- 현재 해결되지 않은 단독 FAIL 영상은 이 README에서 직접 링크합니다.

## Standalone FAIL Evidence

### BUG-UI-01 — 해상도 변경 시 UI 레이아웃 깨짐

- Status: **FAIL**
- Expected: 선택한 해상도가 실제로 적용되고, 변경된 해상도에서도 UI 위치와 크기가 정상 유지되어야 함
- Actual: 과거 UI 레이아웃 깨짐은 수정했지만, 현재는 해상도 변경 자체가 적용되지 않고 1920×1080으로 고정됨
- Video: [해상도 설정 FAIL 영상 보기](https://github.com/user-attachments/assets/30602093-631b-4fdb-905a-ed178d6d7c94)
- Bug Report: [BUG-UI-01 확인](../../Docs/Bug-Reports.md#bug-ui-01--해상도-변경-시-ui-레이아웃-깨짐)
- Detail QA: [Resolution / UI Layout Bug](../../QA-Cases/Resolution-UI-Bug.md)

## Before / After Evidence

- [Before 영상 폴더](./Before/)
- [After 영상 폴더](./After/)
