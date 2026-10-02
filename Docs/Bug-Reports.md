# Bug Reports

이 문서는 HEXIT 개발 과정에서 확인한 대표 이슈를 Bug Report 형식으로 정리한 문서입니다.

---

## BUG-DECK-01 — 상점 구매 카드 덱 편성 수량 미반영

- Priority: High
- Status: FAIL → PASS
- Reproduction Version: `57a3cb6` (2026-04-14)
- Fix Commit: `6e31c27` (2026-04-19)
- Preconditions: 상점에서 신규 카드를 구매한 뒤 덱 편성 화면 진입
- Expected: 구매 카드가 보유 데이터에 등록되고 프로젝트 규칙에 맞는 수량으로 덱 편성 가능
- Actual: 구매 카드는 보유 목록에 나타나지만 신규 카드의 보유 / 선택 수량 데이터가 기존 카드와 다르게 초기화되어 덱 구성 수량이 정상 반영되지 않음
- Cause: 신규 카드 생성 시 `m_number = 1`, `m_selectNumber = 0`으로 저장되고, 선택 시 편성 수량을 보정하지 않던 로직
- Fix: 신규 카드 수량 초기화 및 `AddSelectCard()`의 선택 수량 보정 로직 추가
- Evidence: `57a3cb6` 버전에서 재현 영상 확보 + 수정 Commit 비교

상세: [Shop Purchase / Deck Composition Bug](../QA-Cases/Shop-Deck-Bug.md)

---

## BUG-INTENT-01 — Monster Intent와 실제 행동 불일치

- Priority: Medium
- Status: FAIL → PASS
- Expected: Intent / Animation / 실제 Effect 일치
- Actual: 특정 행동에서 표시와 실제 행동 불일치
- Analysis: MonsterData → MonsterActionData → EffectOption 흐름 분리 검증
- Retest: 동일 조건 및 다른 행동 회귀 테스트

상세: [Monster Intent QA](../QA-Cases/Monster-Intent-QA.md)

---

## BUG-UI-01 — 해상도 변경 시 UI 레이아웃 깨짐

- Priority: Medium
- Status: FAIL
- Condition: 옵션에서 게임 해상도 변경
- Expected: 해상도 변경이 정상 적용되고, 변경된 해상도에서도 UI 위치와 크기가 유지되어야 함
- Actual: 과거 해상도 변경 시 일부 UI 위치가 깨지는 문제를 확인하여 UI 위치 / 크기를 수정했으나, 현재는 해상도 변경 자체가 적용되지 않고 1920×1080으로 고정되는 문제 확인
- Action: UI 레이아웃 깨짐은 수정했지만 해상도 변경 기능은 아직 해결되지 않아 FAIL 유지
- Evidence: 현재 버전에서 해상도 변경 미적용 현상 재현 영상 확보

상세: [Resolution / UI Layout Bug](../QA-Cases/Resolution-UI-Bug.md)

관련 기록:
- 2026-04-18 `6a3d275` — 게임씬 해상도 수정
- 2026-04-19 `0bb2102` — 옵션창, 해상도 조절 깨지는 문제 해결

---

## BUG-MONSTER-01 — 몬스터 사망 후 추가 체력 감소

- Priority: High
- Status: FAIL → PASS
- Condition: 몬스터 HP가 0이 된 뒤 추가 데미지 발생
- Expected: 사망 처리 이후 추가 HP 감소 없음
- Actual: 사망 후에도 체력 감소 처리
- Action: 사망 상태에서 추가 데미지 처리되지 않도록 수정

관련 기록:
- 2026-04-17 몬스터 아이콘 및 죽어도 체력깎이는 오류 해결

---

## BUG-VFX-01 — 스테이지 이펙트 Sorting 오류

- Priority: Medium
- Status: FAIL → 수정 반영
- HEXIT Commit: `808351f` (2026-07-20)
- Commit Message: `스테이지 이펙트 앞으로나오는 버그`
- Main Location:
  - `Assets/GData/PreFabs/Effect/CandleFire.prefab`
  - `Assets/Scenes/Stage.unity`
  - `ProjectSettings/TagManager.asset`
  - 관련 정렬 처리: `Assets/Scripts/UI/OptionSystemUI.cs`, `Assets/Scripts/hahyunwoo/Tutorial/Script/TutorialManager.cs`
- Expected: Background / Monster / Card / UI / Effect / Minimap / Tutorial 등 프로젝트에서 정의한 렌더 순서에 맞게 표시
- Actual: 스테이지 이펙트가 의도한 UI보다 앞쪽에 렌더링되어 UI와 연출의 표시 순서가 깨짐
- Analysis: Commit Diff에서 `CandleFire.prefab`의 ParticleSystemRenderer Sorting Layer와 Stage Canvas의 Sorting Layer가 수정되었고, `Minimap`, `Tutorial` Sorting Layer가 추가됨
- Cause: 일부 Particle / Canvas가 서로 다른 Sorting Layer 또는 Default Layer를 사용하여 화면 표시 우선순위가 일관되지 않았던 것으로 확인
- Fix: Effect / Minimap / Tutorial / Option 영역의 Sorting Layer와 Sorting Order를 다시 정리하고, Tutorial Focus UI도 전용 Sorting Layer를 사용하도록 수정
- Retest: 수정 후 Stage에서 Effect / UI / Tutorial이 동시에 표시되는 상황의 렌더 순서 확인 필요

관련 기록:
- [HEXIT Commit `808351f` — 스테이지 이펙트 앞으로나오는 버그](https://github.com/YounghoHa/Hexit/commit/808351f8f1598be9c7b2a4ad8cb59fbd28dc83b4)

---

## BUG-CARD-01 — 카드 Drag 시작 시 순간이동

- Priority: High
- Status: FAIL → 수정 반영
- HEXIT Commit: `b56c4fb` (2026-04-11)
- Commit Message: `카드 사라지는 이펙트 수정중 / 카드 애니메이션 드래그 순간이동 수정 / 내턴 상대턴 카드 숨기기`
- Main Location:
  - `Assets/GData/PreFabs/GameCard.prefab`
  - `CardTweenUI` 컴포넌트 직렬화 참조
- Expected: 마우스로 카드를 Drag하기 시작하면 현재 카드 위치에서 자연스럽게 Pointer를 따라 이동
- Actual: Drag를 시작하는 순간 카드가 현재 위치에서 다른 위치로 순간적으로 이동한 뒤 Drag가 이어짐
- Analysis: 수정 Commit에서 `GameCard.prefab`의 `m_cardTweenUI` 참조가 연결되고, `CardTweenUI`의 `m_rectT`, `m_canvasGroup` 직렬화 참조가 기존 Null 상태에서 실제 카드 RectTransform / CanvasGroup으로 연결됨
- Cause: Git Diff 기준으로 Drag Animation에서 사용하는 UI 참조가 Prefab에 정상 연결되지 않은 상태가 문제와 관련된 것으로 확인. Commit만으로 런타임 계산식까지는 확정하지 않음
- Fix: `GameCard.prefab`의 CardTweenUI 관련 참조를 정상 연결하고 Drag / Return Animation에 필요한 값을 추가 설정
- Retest: 수정 후 카드 Drag 시작 위치, Pointer 추적, 원위치 복귀 Animation 확인

관련 기록:
- [HEXIT Commit `b56c4fb` — 카드 애니메이션 드래그 순간이동 수정](https://github.com/YounghoHa/Hexit/commit/b56c4fb5453885c390162d8c959fdb6c5a62827f)

