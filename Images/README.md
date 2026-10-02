# Images / Videos

이 폴더에는 포트폴리오에서 사용하는 실제 게임 화면, Before / After 자료, 버그 재현 영상을 정리합니다.

## Structure

```text
Images/
└── videos/
    ├── Before/
    └── After/
```

- `Before/` : 수정 전 버그 재현 영상
- `After/` : 수정 후 정상 동작 / 회귀 테스트 영상

## BUG-MONSTER-01 — 몬스터 처치 후 디버프 공격 지속

아래 이미지는 몬스터 사망 이후에도 남아 있던 디버프 데미지 문제를 수정한 기록입니다.

<img width="708" height="222" alt="BUG-MONSTER-01 fix" src="https://github.com/user-attachments/assets/0d326a2f-2749-444f-b44f-165b616354d4" />

- GameSet에서 몬스터 사망 이후 관련 디버프를 Clear하도록 수정

## BUG-VFX-01 — 스테이지 이펙트 Sorting 오류

<img width="671" height="373" alt="BUG-VFX-01" src="https://github.com/user-attachments/assets/b04a8026-c6fc-44d2-932f-233085b60b78" />

- 스테이지 이펙트 Sorting 오류 수정 기록

## Map UI / UX 변경

<img width="635" height="384" alt="Map UI UX" src="https://github.com/user-attachments/assets/27a6cf0a-059d-412e-9713-d53534e1730b" />

- 맵 이동 씬 변경 및 UI / UX 변경
