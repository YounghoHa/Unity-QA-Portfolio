# Unity QA Portfolio — HEXIT

Unity 기반 로그라이크 카드 전투 게임 **HEXIT**의 QA 포트폴리오입니다.

이 저장소는 전체 게임 소스를 공개하는 목적이 아니라, 실제 개발 과정에서 수행한 **테스트 설계, 버그 재현, 기획 검증, 회귀 테스트, QA 효율화 과정**을 정리하기 위해 제작했습니다.

## Project

- Project: HEXIT
- Genre: Roguelike / Deck Building / Turn-based Card Battle
- Theme: 마법학교
- Engine: Unity
- Platform: PC
- Participation: 2025.08 ~ 2026.10 진행 중
- Role: Programming / Sub Planning / QA

주요 타겟은 덱 빌딩과 턴제 전투에서 전략적인 판단을 즐기는 플레이어입니다.

## QA Scope

게임 플레이에 직접 영향을 주는 다음 영역을 중심으로 검증했습니다.

- 전투 시스템
- 카드 / 덱 시스템
- 맵 / 진행 시스템
- 상점 / 이벤트 연동
- UI / HUD / Tooltip
- Animation / VFX
- Scene Transition
- Tutorial
- QA Test Tool

## QA Approach

단순히 기능이 동작하는지만 확인하지 않고, 다음 기준으로 테스트했습니다.

1. 기능 요구사항과 일치하는가
2. 실제 사용자 시나리오에서 시스템이 정상적으로 연결되는가
3. 경계값과 예외 상황에서 의도하지 않은 결과가 발생하지 않는가
4. 기능이 정상이어도 실제 플레이 경험이 기획 의도와 일치하는가
5. 수정 후 동일 조건과 연관 기능에서 회귀 문제가 발생하지 않는가

자세한 내용은 [QA Process](Docs/QA-Process.md)에서 확인할 수 있습니다.

## Portfolio Contents

### Test Documentation

- [Test Cases](Docs/Test-Cases.md)
- [Bug Reports](Docs/Bug-Reports.md)
- [QA Process](Docs/QA-Process.md)
- [Priority Criteria](Docs/Priority-Criteria.md)
- [Git History Evidence](Docs/Git-History.md)

### Representative QA Cases

- [Map Exploration QA](QA-Cases/Map-Exploration-QA.md)
- [Monster Intent QA](QA-Cases/Monster-Intent-QA.md)
- [Shop Deck Limit Bug](QA-Cases/Shop-Deck-Bug.md)
- [Card Combination → Merge Planning QA](QA-Cases/Card-Merge-Planning-QA.md)

### QA Utility Script

- [BattleTestButton.cs](Scripts/BattleTestButton.cs)

특정 전투 상태까지 매번 처음부터 진행하지 않고, 체력 회복과 공격력 버프 상태를 즉시 만들어 반복 테스트할 수 있도록 사용한 수동 테스트 도구입니다.

## Repository Notice

원본 HEXIT Unity 프로젝트는 팀 작업물, 서드파티 리소스 및 프로젝트 소스 보호를 위해 **Private Repository**로 관리하고 있습니다.

이 Public Repository에는 포트폴리오 목적으로 선별한 QA 문서와 일부 테스트용 코드만 포함합니다.

## Status Legend

| Status | Meaning |
|---|---|
| PASS | 기대 결과와 실제 결과가 일치 |
| FAIL | 기대 결과와 실제 결과 불일치 |
| FAIL → PASS | 문제 발견 후 수정 및 재검증 완료 |
| Planning FAIL | 기능은 동작하지만 기획 목적을 충족하지 못함 |
| UX 개선 필요 | 기능은 정상이나 플레이 경험 개선 필요 |
| 확인 필요 | Git 기록만으로 최종 상태를 확정하기 어려움 |
