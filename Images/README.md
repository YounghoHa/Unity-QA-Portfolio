# Images / Videos

이 폴더에는 포트폴리오에서 사용하는 실제 게임 화면, Before / After 자료, 버그 재현 영상을 정리합니다.

## Structure

```text
Images/
└── videos/
    ├── Before/
    └── After/
```

- `Before/` : 수정 전 버그 재현 영상
- `After/` : 수정 후 정상 동작 / 회귀 테스트 영상

## Before Videos

현재 확보한 수정 전 재현 영상 3개는 아래 이름으로 정리합니다.

1. `01-shop-deck-bug.mp4`
   - 상점에서 신규 카드 구매 후 덱 편성 데이터가 정상 반영되지 않는 문제
   - 재현 기준 버전: `57a3cb6`

2. `02-monster-skill-defense-mismatch.mp4`
   - 스킬을 사용해야 할 때 방어를 사용하고, 방어를 해야 할 때 스킬을 사용하는 문제
   - 스킬 효과: 턴 종료 시 카드 드로우 제한

3. `03-cloud-slime-intent-skill-bug.mp4`
   - Cloud Slime 행동 아이콘이 갱신되지 않는 문제
   - 실드 행동에서 과부하 감소가 적용되고, 방어 행동에서 스킬이 실행되는 문제

## Screenshot Naming

추천 파일명:

- map-before-hidden-nodes.png
- map-after-corridor.png
- map-corridor-visual-improvement.png
- monster-intent-before.png
- monster-intent-after.png
- shop-deck-bug-before.png
- shop-deck-fixed-after.png
- battle-test-buttons.png
- monster-animation-before.gif
- monster-animation-after.gif

## Rule

- 같은 버그의 수정 전 / 수정 후 자료는 가능한 한 같은 해상도로 기록
- 버그 영상은 재현 조건이 보이도록 필요한 흐름을 포함
- 화면 녹화 파일명 대신 내용이 드러나는 영문 이름으로 정리
- 팀원 개인정보나 유료 에셋 라이선스 정보가 노출되지 않도록 확인


## After Videos

수정 후 동일 기능을 다시 확인한 영상 3개는 아래 이름으로 정리합니다.

1. `01-shop-deck-after.mp4`
   - 상점에서 신규 카드 구매 후 보유 / 선택 수량과 덱 편성이 정상 반영되는지 재검증
   - 원본 파일: `화면 녹화 중 2026-10-02 035559.mp4`

2. `02-monster-skill-defense-after.mp4`
   - 스킬 / 방어 행동이 Intent에 맞게 실행되는지 재검증
   - 원본 파일: `20261001-1848-43.2924805.mp4`

3. `03-cloud-slime-intent-skill-after.mp4`
   - Cloud Slime 아이콘 갱신과 과부하 감소 스킬 적용 타이밍을 재검증
   - 원본 파일: `화면 녹화 중 2026-10-02 035029.mp4`
