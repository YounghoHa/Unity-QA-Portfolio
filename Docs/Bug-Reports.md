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
- Status: FAIL → PASS
- Condition: 게임 해상도 변경
- Expected: UI 위치와 크기 유지
- Actual: 일부 UI 위치가 깨짐
- Action: 해상도 조건에 맞게 UI 수정 후 재확인

관련 기록:
- 2026-04-18 게임씬 해상도 수정
- 2026-04-19 해상도 조절 깨지는 문제 해결

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
