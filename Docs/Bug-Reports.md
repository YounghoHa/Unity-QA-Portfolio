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

## BUG-MONSTER-01 — 몬스터 처치 후 디버프 공격이 다음 스테이지에서 발동

- Priority: High
- Status: FAIL → PASS
- Condition: 플레이어에게 지속 공격 / 디버프 효과를 부여하는 몬스터를 처치한 뒤 다음 스테이지로 이동
- Expected: 몬스터가 사망하면 해당 몬스터가 남긴 공격성 디버프 / 지속 효과가 종료되어 다음 스테이지에서 플레이어에게 데미지를 주지 않아야 함
- Actual: 몬스터를 처치했음에도 해당 몬스터의 능력이 남아 다음 스테이지에서 발동하고 플레이어에게 데미지가 들어오는 현상 발생
- Cause: 몬스터 사망 처리 이후 전투 중 적용된 디버프 상태가 정리되지 않고 다음 전투 상태까지 유지됨
- Fix: 몬스터 사망 처리 시 관련 디버프를 정리하도록 수정
- Retest: 몬스터 처치 → 다음 스테이지 이동 후 동일 디버프 데미지가 발생하지 않는지 재확인

상세: [Monster Debuff After Death Bug](../QA-Cases/Monster-Debuff-Death-Bug.md)

관련 기록:
- 2026-04-17 몬스터 아이콘 및 죽어도 체력깎이는 오류 해결

---

## BUG-VFX-01 — 스테이지 이펙트 Sorting 오류

- Priority: Low
- Status: FAIL → 수정 반영
- Condition: Stage에서 Effect / UI / Tutorial 요소가 동시에 표시되는 상황
- Expected: Background / Monster / Card / UI / Effect / Minimap / Tutorial이 프로젝트에서 정의한 렌더 순서에 맞게 표시
- Actual: 특정 스테이지 이펙트가 의도한 UI보다 앞쪽에 렌더링되어 화면 표시 우선순위가 깨짐
- Cause: 일부 Particle / Canvas가 서로 다른 Sorting Layer 또는 Default Layer를 사용해 렌더 우선순위가 일관되지 않음
- Fix: Effect / Minimap / Tutorial / Option 영역의 Sorting Layer와 Sorting Order를 다시 정리
- Retest: Stage에서 Effect / UI / Tutorial을 동시에 표시해 렌더 순서 재확인

상세: [Stage Effect Sorting Bug](../QA-Cases/Stage-Effect-Sorting-Bug.md)

관련 기록:
- 2026-07-20 `808351f` — 스테이지 이펙트 앞으로나오는 버그

---

## BUG-CARD-01 — 카드 Drag 시작 시 순간이동

- Priority: Medium
- Status: FAIL → PASS
- Condition: 손패의 카드를 마우스로 Drag 시작
- Expected: 카드를 잡은 현재 위치에서 자연스럽게 Pointer를 따라 이동
- Actual: Drag 시작 순간 카드가 다른 위치로 순간이동한 뒤 Drag가 이어짐
- Cause: Drag Animation에 사용하는 CardTweenUI / RectTransform / CanvasGroup 참조가 정상 연결되지 않은 상태가 문제와 관련된 것으로 확인
- Fix: GameCard Prefab의 CardTweenUI 관련 참조와 Drag / Return Animation 설정을 정리
- Retest: 동일 카드에서 Drag 시작 위치, Pointer 추적, 원위치 복귀를 재검증하여 순간이동 현상이 사라진 것을 확인

상세: [Card Drag Jump Bug](../QA-Cases/Card-Drag-Jump-Bug.md)

관련 기록:
- 2026-04-11 `b56c4fb` — 카드 애니메이션 드래그 순간이동 수정

