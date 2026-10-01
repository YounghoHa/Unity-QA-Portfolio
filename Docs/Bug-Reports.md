# Bug Reports

이 문서는 HEXIT 개발 과정에서 확인한 대표 이슈를 Bug Report 형식으로 정리한 문서입니다.

---

## BUG-DECK-01 — 상점 구매 후 덱 최대 수량 초과

- Priority: High
- Status: FAIL → PASS
- Preconditions: 덱 8장, 구매 가능한 골드 보유
- Expected: 최대 8장 유지
- Actual: 구매 후 9장 보유
- Impact: 덱 규칙 위반 및 이후 Draw / 전투 밸런스 영향
- Retest: 수정 후 동일 조건 재검증

상세: [Shop Deck Limit Bug](../QA-Cases/Shop-Deck-Bug.md)

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
