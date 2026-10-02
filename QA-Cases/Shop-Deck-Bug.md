# Bug Report — Shop Purchase / Deck Composition

## ID

BUG-DECK-01

## Title

상점에서 구매한 신규 카드가 덱 편성 수량에 정상 반영되지 않는 문제

## Priority

**High**

## Reproduction Version

- Commit: `57a3cb6`
- Message: `게이지 오류 수정, 상점 이후 보스연결 완`
- 해당 버전을 다시 실행하여 상점 구매 후 덱 편성 문제를 재현하고 녹화했습니다.

## Precondition

- 상점에서 구매 가능한 골드 보유
- 신규 카드 구매 가능
- 이후 덱 편성 화면 진입 가능

## Steps to Reproduce

1. 상점에 진입합니다.
2. 신규 카드를 구매합니다.
3. 이후 덱 편성 화면으로 이동합니다.
4. 구매한 카드를 선택합니다.
5. 보유 수량과 덱 편성 수량 변화를 확인합니다.

## Expected Result

상점에서 구매한 신규 카드가 보유 카드 데이터에 정상 등록되고, 프로젝트의 카드 편성 규칙에 맞는 수량으로 덱에 반영되어야 합니다.

## Actual Result

구매한 신규 카드는 보유 목록에 나타났지만, 신규 카드의 보유 수량 / 선택 수량 데이터가 기존 카드와 다르게 초기화되어 덱 편성 수량이 정상적으로 반영되지 않았습니다.

**Status: FAIL**

## Cause Analysis

수정 커밋 `6e31c27`의 코드 차이를 확인한 결과, 신규 카드 획득 시 저장되는 카드 수량 데이터가 덱 편성 규칙과 맞지 않았습니다.

수정 전 신규 카드 생성 시:

- `m_number = 1`
- `m_selectNumber = 0`
- `m_selectFlag = false`

상태로 저장되었습니다.

또한 `AddSelectCard()`에서는 선택 Flag만 변경하고 `m_selectNumber`를 보정하지 않아, 구매 카드가 덱 편성 대상으로 선택되더라도 실제 편성 수량이 정상적으로 반영되지 않을 수 있었습니다.

## Fix

2026-04-19 커밋 `6e31c27`에서 다음 로직이 수정되었습니다.

- 신규 카드의 기본 보유 수량 보정
- 신규 카드의 선택 수량 초기화
- 카드 선택 시 `m_selectNumber <= 0`이면 편성 수량 재설정
- 선택 수량이 실제 보유 수량을 초과하지 않도록 제한
- 카드 제거 시 `m_selectNumber = 0` 처리
- 상점 구매 시 Null 방어 코드 추가

## Retest

수정 버전에서는 상점 / 랜덤 이벤트로 획득한 카드가 보유 데이터에 추가되고, 덱 선택 수량이 정상적으로 반영되도록 변경되었습니다.

**Status: FAIL → PASS**

## Evidence

- Reproduction video: 2026-10-02에 `57a3cb6` 버전을 다시 실행하여 버그 재현 영상 확보
- Git History: 수정 전 버전과 수정 커밋 비교

- Before: [버그 재현 영상 보기](../Images/videos/Before/01-shop-deck-bug.mp4.mp4)
- After: [수정 후 영상 보기](../Images/videos/After/01-shop-deck-after.mp4.mp4)

## Related History

| Date | Commit | Message | Meaning |
|---|---|---|---|
| 2026-04-14 | `57a3cb6` | 게이지 오류 수정, 상점 이후 보스연결 완 | 버그 재현에 사용한 버전 |
| 2026-04-19 | `6e31c27` | 상점, 랜덤이벤트 구매 시 / 덱 구성 안되던 버그 수정 | 카드 보유 / 선택 수량 및 덱 편성 로직 수정 |
