# Test Cases

HEXIT 개발 과정에서 실제로 구현·수정·검증한 기능을 기준으로 정리한 테스트 목록입니다.

일부 항목은 Git 기록만으로 최종 상태를 확정하기 어려워 **확인 필요**로 표시했습니다.

| ID | Category | Test Item | Condition | Expected Result | Actual Result | Status |
|---|---|---|---|---|---|---|
| TC-01 | Card | 카드 기본 사용 | AP ≥ 카드 비용 | AP 차감 후 카드 효과 발동 | AP 정상 차감 및 효과 적용 | PASS |
| TC-02 | Card | AP 부족 상태 사용 | AP 부족 | 카드 사용 불가 | 입력 차단 | PASS |
| TC-03 | Card | 손패 최대 드로우 제한 | 손패 8장 | 추가 카드가 손패에 들어오지 않음 | 8장 이상 드로우 제한 적용 | PASS |
| TC-04 | Card | 카드 드로우 정상 동작 | 일반 전투 진행 | 지정 수만큼 카드 드로우 | 드로우 버그 발생 후 수정 | FAIL → PASS |
| TC-05 | Card | 덱 소진 후 리필 | 덱 전량 소진 | 덱 재구성 후 드로우 지속 | 리필 구조 적용 | PASS |
| TC-06 | Card | 영구 실드 | 영구 실드 카드 사용 | 턴 종료 후 실드 유지 | 정상 유지 | PASS |
| TC-07 | Card | 일반 실드 종료 | 일반 실드 사용 후 턴 진행 | 지정 턴 이후 해제 | 실드 로직 반복 수정 | 확인 필요 |
| TC-08 | Card | 과부하 증가 | 공격 카드 사용 | 지정 수치만큼 증가 | 정상 증가 | PASS |
| TC-09 | Planning | 서로 다른 카드 조합 | 조합 가능한 카드 사용 | 기획된 조합 카드 생성 | 기능은 가능하나 암기 부담 발생 | Planning FAIL |
| TC-10 | Card | 동일 카드 Merge | 동일 카드 조합 | 상위 카드 생성 | Merge 방식으로 변경 | PASS |
| TC-11 | Card UI | 카드 Drag & Drop | 카드 Drag 후 Drop | 자연스럽게 이동 후 입력 종료 | Animation / Trigger 충돌 발생 | FAIL → PASS |
| TC-12 | Card UI | 애니메이션 중 추가 입력 | 카드 이동 애니메이션 진행 중 | 종료 전 다른 카드에 영향 없음 | 다른 카드 애니메이션에 영향 | FAIL → PASS |
| TC-13 | Deck | 최대 덱 수량 | 8장 보유 후 상점 구매 | 8장 초과 불가 | 구매 후 9장 보유 | FAIL |
| TC-14 | Deck | 최대 덱 수량 수정 후 | 8장 보유 후 구매 | 최대 수량 유지 | 제한 정상 적용 | FAIL → PASS |
| TC-15 | Deck | 상점 구매 카드 반영 | 상점 카드 구매 | 구매 카드가 덱에 정상 반영 | 덱 구성 안 되는 버그 발생 | FAIL |
| TC-16 | Deck | 랜덤 이벤트 카드 반영 | 이벤트 카드 획득 | 덱에 정상 반영 | 덱 구성 버그 수정 | FAIL → PASS |
| TC-17 | Battle | Monster Intent 표시 | 특정 행동 선택 | Intent와 실제 행동 일치 | 특정 조건에서 불일치 | FAIL |
| TC-18 | Battle | Intent 수정 후 회귀 | 문제 행동 및 다른 행동 실행 | Intent / Animation / Effect 일치 | 수정 후 회귀 테스트 | PASS |
| TC-19 | Battle | 몬스터 행동 선택 | 여러 행동 후보 | 설정된 조건/확률에 따라 행동 선택 | 패턴 테스트 기록 | 확인 필요 |
| TC-20 | Battle | 몬스터 공격 애니메이션 | 공격 행동 | 공격 모션 재생 후 효과 적용 | 공격 애니메이션 실패 기록 | FAIL |
| TC-21 | Battle | 몬스터 사망 후 데미지 | HP 0 후 추가 공격 | 추가 체력 감소 없음 | 죽은 뒤에도 HP 감소 | FAIL |
| TC-22 | Battle | 사망 처리 수정 후 | HP 0 상태 | 추가 데미지 처리 안 됨 | 오류 해결 | FAIL → PASS |
| TC-23 | Battle UI | 몬스터 HP 게이지 | 데미지 발생 | 실제 HP와 게이지 동기화 | 게이지 오류 발생 | FAIL |
| TC-24 | Battle UI | 몬스터 게이지 수정 후 | 데미지 / Shield 발생 | HP / Shield 정상 표시 | 수정 완료 | FAIL → PASS |
| TC-25 | Battle UI | 다중 몬스터 HP 표시 | 여러 몬스터 등장 | 각 몬스터 상태 구분 가능 | 우측 고정 HUD 구조 한계 | UX 개선 필요 |
| TC-26 | Battle UI | 개별 몬스터 게이지 | 여러 몬스터 등장 | 각 몬스터별 HP / Shield 표시 | 개별 게이지 방식으로 변경 | PASS |
| TC-27 | Player | 패배 처리 | Player HP 0 | 패배 상태 정상 저장 | HP 0 관련 버그 발생 | FAIL |
| TC-28 | Player | 승리 후 HP 저장 | 전투 승리 | 남은 HP 정상 유지 | 승리 시 HP 저장 적용 | PASS |
| TC-29 | Turn | 턴 종료 버튼 | 사용 불가 상태 | 잘못된 시점에 턴 종료 불가 | 버튼 비활성화 적용 | PASS |
| TC-30 | Map | 미래 노드 정보 제한 | 미래 노드 ? 표시 | 미래 구조 확인 불가 | 스크롤 시 전체 구조 노출 | Planning FAIL |
| TC-31 | Map | 미래 노드 구조 개선 | 재설계된 맵 | 현재 이동 가능 노드만 표시 | 사전 노출 제거 | PASS |
| TC-32 | Map | 미니맵 진행 표시 | 스테이지 진행 | 진행 위치 확인 가능 | 미니맵 및 이동씬 완료 | PASS |
| TC-33 | Map | 맵 이동씬 1차 구현 | 노드 선택 후 이동 | 정상 진행 흐름 유지 | 미완 상태로 판단 후 Revert | FAIL |
| TC-34 | Map | 맵 이동씬 재구현 | Revert 후 재작업 | 이동 / 미니맵 정상 연결 | 완료 버전 반영 | FAIL → PASS |
| TC-35 | Map UX | 3D 복도 선택 화면 | 다음 스테이지 선택 | 공간 탐색 느낌 및 선택 피드백 | 기능 정상, 화면이 밋밋함 | UX 개선 필요 |
| TC-36 | Map UX | 복도 연출 개선 | 원근 / 조명 / Shader 적용 | 깊이감과 선택 피드백 개선 | 시각적 개선 적용 | PASS |
| TC-37 | Shop | 카드 구매 | 충분한 골드 | 골드 차감 후 카드 획득 | 구매 기능 정상 | PASS |
| TC-38 | Shop | Normal 카드 등장 제한 | 상점 카드 생성 | 기획된 등급만 등장 | Normal 미등장 처리 | PASS |
| TC-39 | Shop | 상점 이후 진행 | 상점 이용 완료 | 다음 보스 / 스테이지 정상 연결 | 보스 연결 완료 | PASS |
| TC-40 | Balance | 상점 이용 후 난이도 | 상점 방문 후 전투 | 난이도가 과도하게 하락하지 않음 | 클리어 난이도 급락 | Balance FAIL |
| TC-41 | Balance | 스테이지별 등장 확률 | 진행 단계 변경 | 단계별 카드 확률 적용 | 구조 구현, 적용 여부 불명확 | 확인 필요 |
| TC-42 | UI | 해상도 변경 | 게임 해상도 변경 | UI 레이아웃 유지 | UI 깨짐 발생 | FAIL |
| TC-43 | UI | 해상도 수정 후 | 다양한 해상도 | UI 정상 유지 | 문제 해결 | FAIL → PASS |
| TC-44 | UI | Tooltip 표시 | Card / Monster Hover | Tooltip 정상 표시 | 수정 과정에서 다수 오류 | FAIL |
| TC-45 | UI | Tooltip 수정 후 | 동일 조건 | Tooltip 정상 표시 | 후속 수정 기록 | 확인 필요 |
| TC-46 | UI | Effect Sorting | UI / Effect 동시 표시 | 지정 순서 유지 | Effect가 앞으로 노출 | FAIL |
| TC-47 | UI | Sorting 수정 후 | Tutorial / UI / Effect 동시 표시 | 의도한 렌더링 순서 | 정렬 구조 수정 | FAIL → PASS |
| TC-48 | Animation | 몬스터 기본 Animation | Idle / Attack 실행 | 행동에 맞는 Animation | 수정 중 오류 발생 | FAIL |
| TC-49 | Animation | 몬스터 공격 Animation | 공격 행동 | 공격 모션 정상 재생 | 명시적 실패 기록 | FAIL |
| TC-50 | Animation | Bone Animation | 몬스터 행동 | 단일 이미지보다 자연스러운 움직임 | Bone Animation 적용 | PASS |
| TC-51 | Animation | Player Animation | 행동 상태 전환 | 상태별 Animation 정상 | 완료 기록 | PASS |
| TC-52 | VFX | 공격 이펙트 | 공격 실행 | 타격 VFX 출력 | 공격 이펙트 완료 | PASS |
| TC-53 | VFX | 노드 Glow | 노드 강조 | 자연스러운 빛번짐 | 구현 실패 기록 | FAIL |
| TC-54 | VFX | 카드 이펙트 | 카드 효과 발동 | 설정 VFX 재생 | 구현 중 오류 발생 | FAIL |
| TC-55 | VFX | 방어 이펙트 | Shield / Guard | 방어 상태 VFX 출력 | 반복 수정 | 확인 필요 |
| TC-56 | Scene | 로딩 화면 | Scene 전환 | 빈 화면 / 깜빡임 없이 전환 | 지속 수정 발생 | FAIL → 개선 |
| TC-57 | Scene | 로딩 Animation | Scene Load | Transition 후 다음 Scene 표시 | 변경 및 재수정 기록 | 확인 필요 |
| TC-58 | Tutorial | Tutorial 전체 진행 | 최초 진입 | 순서대로 안내 | 여러 차례 수정 | FAIL → PASS |
| TC-59 | Tutorial | Tutorial 최종 흐름 | 전체 진행 | 중단 없이 완료 | BIC 최종 2차 수정 | PASS |
| TC-60 | QA Tool | Heal Test Button | 전투 중 Button 클릭 | HP 즉시 회복 | 정상 사용 | PASS |
| TC-61 | QA Tool | Attack Buff Button | 전투 중 Button 클릭 | 지정 Buff 적용 | 정상 사용 | PASS |
| TC-62 | QA Tool | 동일 상태 반복 재현 | 동일 테스트 반복 | 같은 조건 빠르게 생성 | BattleTestButton 활용 | PASS |

## Next

각 테스트 케이스 중 포트폴리오에서 강조할 항목은 별도의 QA Case 또는 Bug Report 문서로 상세화합니다.
