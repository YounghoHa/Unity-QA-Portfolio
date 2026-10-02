# Bug Report — Card Drag Jump

## ID

BUG-CARD-01

## Title

카드 Drag 시작 시 순간이동하는 문제

## Priority

**High**

## Status

**FAIL → PASS**

## Issue

손패에 있는 카드를 마우스로 Drag할 때, 카드를 잡은 현재 위치에서 자연스럽게 이동하지 않고 Drag 시작 순간 다른 위치로 순간적으로 이동한 뒤 Pointer를 따라가는 문제를 확인했습니다.

카드 사용은 전투에서 반복적으로 사용하는 핵심 입력이기 때문에 Drag 시작 위치가 튀면 조작감이 불안정하게 느껴지고, 플레이어가 의도하지 않은 위치로 카드가 이동한 것처럼 보일 수 있습니다.

## Reproduction Condition

- 전투 중 손패에 사용 가능한 카드 존재
- 마우스로 카드 Drag 가능
- 카드 Drag / Return Animation이 활성화된 상태

## Steps to Reproduce

1. 전투 화면에서 손패의 카드를 선택합니다.
2. 카드 위에서 마우스 Drag를 시작합니다.
3. Drag가 시작되는 첫 프레임의 카드 위치를 확인합니다.
4. Pointer를 이동하여 카드 추적 위치를 확인합니다.
5. Drag를 취소하거나 원위치로 복귀시켜 Return Animation을 확인합니다.

## Expected Result

- Drag 시작 시 카드가 현재 위치에서 바로 Pointer를 따라가야 합니다.
- Drag 시작 순간 위치가 갑자기 바뀌면 안 됩니다.
- Drag 취소 후 원래 손패 위치로 자연스럽게 복귀해야 합니다.

## Actual Result

- Drag를 시작하는 순간 카드가 현재 위치에서 다른 위치로 순간이동했습니다.
- 이후에는 Pointer를 따라 이동하지만 시작 지점이 끊겨 보여 Drag Animation이 부자연스러웠습니다.

## Analysis

관련 수정 기록에서 `GameCard.prefab`의 CardTweenUI 관련 참조가 정리된 것을 확인했습니다.

수정 과정에서 확인된 주요 항목:

- `m_cardTweenUI`
- `m_rectT`
- `m_canvasGroup`
- Drag / Return Animation 관련 설정

Git 기록상 해당 참조들이 카드 Drag Animation 동작과 함께 수정되었으며, Drag 시작 위치가 순간적으로 변경되는 문제와 관련된 부분으로 확인했습니다.

## Cause Analysis

Drag Animation에서 사용하는 UI 참조가 Prefab에 정상적으로 연결되지 않은 상태가 문제와 관련된 것으로 확인했습니다.

Commit 기록만으로 Drag 위치 계산식 자체까지 단정하지 않고, Prefab 참조 및 Tween 처리 영역을 문제 발생 지점으로 정리했습니다.

## Fix

- GameCard Prefab의 CardTweenUI 관련 참조 연결
- RectTransform / CanvasGroup 참조 정리
- Drag / Return Animation에 필요한 설정 보완

## Retest

수정 후 동일한 카드 Drag 동작을 다시 테스트했습니다.

확인 항목:

- Drag 시작 위치
- Pointer 추적
- Drag 중 카드 이동
- Drag 취소 후 원위치 복귀

After 영상에서 Drag 시작 시 발생하던 순간이동 현상이 사라지고 현재 위치에서 자연스럽게 Drag가 시작되는 것을 확인했습니다.

**Status: FAIL → PASS**

## Evidence

- Before: [카드 Drag 순간이동 재현 영상](../Images/videos/Before/05-card-drag-jump-before.mp4)
- After: [카드 Drag 수정 후 영상](../Images/videos/After/05-card-drag-jump-after.mp4)
- 관련 기록: 2026-04-11 `b56c4fb` — 카드 애니메이션 드래그 순간이동 수정
