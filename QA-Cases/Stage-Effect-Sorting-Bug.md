# Bug Report — Stage Effect Sorting

## ID

BUG-VFX-01

## Title

스테이지 이펙트가 의도한 UI보다 앞쪽에 렌더링되는 문제

## Priority

**Low**

## Status

**FAIL → 수정 반영**

## Issue

Stage 화면에서 이펙트와 UI가 동시에 표시될 때, 특정 스테이지 이펙트가 의도한 UI보다 앞쪽에 렌더링되는 문제를 확인했습니다.

프로젝트에서는 Background / Monster / Card / UI / Effect / Minimap / Tutorial 등의 화면 표시 순서를 구분해 사용하고 있었기 때문에, 각 요소는 지정된 Sorting Layer와 Sorting Order 기준으로 일관되게 표시되어야 합니다.

하지만 일부 Particle / Canvas가 다른 Sorting Layer 또는 Default Layer를 사용하면서 이펙트가 UI보다 앞에 노출되는 현상이 발생했습니다.

## Reproduction Condition

- Stage Scene 진입
- Stage Effect 활성화
- UI 또는 Tutorial 요소가 동시에 표시되는 상황

## Steps to Reproduce

1. Stage Scene에 진입합니다.
2. 스테이지 이펙트가 표시되는 상태를 만듭니다.
3. UI / Minimap / Tutorial 요소를 함께 표시합니다.
4. 이펙트와 UI의 앞뒤 표시 순서를 확인합니다.

## Expected Result

- Background / Monster / Card / UI / Effect / Minimap / Tutorial이 프로젝트에서 정의한 순서에 맞게 표시되어야 합니다.
- 특정 Particle이나 Canvas가 다른 UI 요소보다 의도치 않게 앞쪽에 렌더링되면 안 됩니다.
- Tutorial Focus UI 역시 전용 Sorting Layer 기준으로 가장 앞쪽에서 정상 표시되어야 합니다.

## Actual Result

- 특정 스테이지 이펙트가 UI보다 앞쪽에 렌더링되었습니다.
- 화면 요소별 Sorting Layer가 일관되지 않아 의도한 표시 우선순위가 깨졌습니다.
- 이로 인해 UI와 연출 요소가 겹치는 상황에서 시각적인 가독성이 떨어졌습니다.

## Analysis

관련 변경 기록에서 다음 영역의 Sorting 설정이 함께 수정된 것을 확인했습니다.

- `Assets/GData/PreFabs/Effect/CandleFire.prefab`
- `Assets/Scenes/Stage.unity`
- `ProjectSettings/TagManager.asset`
- `Assets/Scripts/UI/OptionSystemUI.cs`
- `Assets/Scripts/hahyunwoo/Tutorial/Script/TutorialManager.cs`

또한 ParticleSystemRenderer의 Sorting Layer, Stage Canvas의 Sorting Layer, Minimap / Tutorial 전용 Sorting Layer가 함께 정리된 이력이 있습니다.

문제는 특정 이펙트 하나만의 오류라기보다, 여러 Canvas / Particle이 서로 다른 기준으로 정렬되면서 화면 표시 우선순위가 일관되지 않았던 점에 있었습니다.

## Cause Analysis

- 일부 Particle이 Default 또는 다른 Sorting Layer를 사용
- Stage Canvas와 Effect의 Sorting Layer 기준이 일치하지 않음
- Minimap / Tutorial 등 전용 UI 영역에 별도 Sorting Layer가 필요했음

이로 인해 Effect / UI / Tutorial 간 렌더링 우선순위가 의도한 구조와 다르게 표시되었습니다.

## Fix

다음 영역의 Sorting Layer와 Sorting Order를 다시 정리했습니다.

- Effect
- Minimap
- Tutorial
- Option UI
- Tutorial Focus UI

각 화면 요소가 같은 기준으로 정렬되도록 수정하고, Tutorial Focus UI는 전용 Sorting Layer를 사용하도록 변경했습니다.

## Retest

수정 후에는 다음 상황을 중심으로 다시 확인해야 합니다.

- Stage Effect + 일반 UI 동시 표시
- Stage Effect + Minimap 동시 표시
- Stage Effect + Tutorial 동시 표시
- Tutorial Focus UI가 다른 Effect보다 정상적으로 앞에 표시되는지 확인

현재 Git 기록상 수정 반영 이력은 확인되며, 최종 회귀 확인 전까지 상태는 **FAIL → 수정 반영**으로 유지합니다.

## Evidence

- Image Evidence: [수정 이미지 확인](../Images/README.md#bug-vfx-01--스테이지-이펙트-sorting-오류)
- 관련 기록: 2026-07-20 `808351f` — 스테이지 이펙트 앞으로나오는 버그
