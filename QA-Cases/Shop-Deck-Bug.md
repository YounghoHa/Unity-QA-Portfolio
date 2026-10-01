# Bug Report — Shop Deck Limit

## ID

BUG-DECK-01

## Title

상점 카드 구매 후 최대 덱 보유량 8장 초과

## Priority

**High**

## Precondition

- 플레이어가 이미 카드 8장을 보유
- 상점 진입 가능
- 카드 구매가 가능한 골드 보유

## Steps to Reproduce

1. 덱을 8장으로 구성
2. 상점에 진입
3. 카드 구매
4. 구매 후 덱 카드 수 확인

## Expected Result

덱 최대 보유량 8장을 초과하지 않아야 합니다.

## Actual Result

구매한 카드가 추가되어 덱이 9장이 되는 현상을 확인했습니다.

## Impact

덱 최대 수량 규칙을 위반하며, 이후 전투의 카드 Draw와 밸런스에 영향을 줄 수 있습니다.

## Action

카드 구매 / 획득 시 덱 보유량을 확인하도록 수정했습니다.

상점뿐 아니라 랜덤 이벤트에서 카드 획득 시에도 덱 구성 결과를 함께 확인했습니다.

## Retest

동일 조건에서 다시 구매 테스트를 진행하여 최대 수량 제한을 확인했습니다.

**Status: FAIL → PASS**

## Related History

2026-04-19  
상점, 랜덤이벤트 구매 시 덱 구성 안되던 버그 수정
