# QA Case — Monster Intent Validation

## Issue

특정 몬스터 행동에서 체력바 상단에 표시되는 Intent와 실제 행동이 일치하지 않는 현상을 확인했습니다.

## Expected

Intent 아이콘, 애니메이션, 실제 Effect가 같은 행동을 나타내야 합니다.

## Analysis

전체 전투를 한 번에 확인하지 않고 데이터 전달 흐름을 분리했습니다.

MonsterData  
→ MonsterActionData  
→ 행동 선택  
→ Intent 표시  
→ Animation  
→ EffectOption

각 단계의 결과를 따로 확인하여 어느 단계에서 표시 데이터와 실제 적용 데이터가 달라지는지 발생 조건을 좁혔습니다.

## Test Method

- 행동 선택 결과 확인
- Intent Sprite 확인
- 실제 Animation 확인
- EffectOption 적용 결과 확인
- 동일 조건 반복
- 다른 행동에 대한 회귀 테스트

## Result

문제 발생 조건을 특정하여 수정한 뒤 동일 조건과 다른 행동을 다시 테스트했습니다.

**Status: FAIL → PASS**

## QA Value

문제를 단순히 "아이콘이 틀림"으로 기록하지 않고, 데이터 흐름을 분리해 실제 오류 발생 지점을 찾는 방식으로 검증했습니다.


## Evidence

### Monster Skill / Defense
- Before: [버그 재현 영상 보기](.../Images/videos/Before/02-cloud-skill-defense-mismatch.mp4.mp4)
- After: [수정 후 영상 보기](.../Images/videos/After/02-cloud-skill-defense-after.mp4.mp4)

### Cloud Slime
- Before: [버그 재현 영상 보기](.../Images/videos/Before/03-slime-intent-skill-bug.mp4.mp4)
- After: [수정 후 영상 보기](.../Images/videos/After/03-slime-intent-skill-after.mp4.mp4)
