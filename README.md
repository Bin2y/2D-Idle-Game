# Simple 2D Idle Game
## 📖 목차
1. [프로젝트 소개](#프로젝트-소개)
2. [주요기능](#주요기능)
3. [개발기간](#개발기간)
4. [와이어프레임](#와이어프레임)
5. [프로젝트 파일 구조](#프로젝트-파일-구조)
6. [Trouble Shooting](#trouble-shooting)
    
## 👨‍🏫 프로젝트 소개
간단한 방치형 RPG게임으로 캐릭터가 자동으로 몬스터를 추적하여 공격하고 몬스터는 죽으면 죽을수록 계속해서 강해지는 게임이다.


## 💜 주요기능
- FSM
  - 플레이어의 상태는 Idle, Chasing, Attack 상태로 Animation Event로 공격을 주는 데미지 기능을 구현
  - Idle에서 적이 근처에있다면 Chasing하고 때릴 수 있을정도록 가깝다면 바로 Attack상태로 들어간다.
  - Chasing, Attack에서는 적이 없다면 Idle상태로 들어간다.
  - Rigidbody로 2D 움직임을 구현하였다.

- Inventory
  - Uncommon, Common, Rare, Epic, Legendary로 구현되어있다. 또한 각 등급별로 5개의 랭크를 가지고있다.
  - 해당 랭크에서 다음 랭크로 가려면 합성을 25개를하면 다음 랭크 1개가 되고 만약 최고랭크에 도달했을시에는 다음 등급으로 합성이되는 방식이다.
  - 물론 마지막 등급과 랭크를 가진 아이템은 합성이 되지 않는다.

- Character Stat
  - 스탯을 재화로 올릴 수 있고 해당 재화로 올라간 수치는 UI를 통해서 따로 표시한다.

- BigInteger
  - 재화를 BigInteger로 구현하였으며 1000단위로 알파벳 순서 a,b,c,d,e,f 까지 화면에 표현되게 구현하였다.
  - BigInteger를 따로 알파벳 유닛으로 바꾸는 기능이 없어서 직접 BigInteger 클래스에 구현


## ⏲️ 개발기간
- 2024.06.14(월) ~ 2024.06.18(화)


## 와이어프레임
![image](https://github.com/Bin2y/2D-Idle-Game/assets/37493119/f219b7d4-d44f-41c6-819d-f219b1078f58)




## 프로젝트 파일 구조
├───BigInteger   
├───CharacterController   
├───Combat   
├───Enemy   
├───Manager   
├───Player   
├───UI   
│   ├───_CharcterUI   
│   ├───_InventoryUI   
│   │   └───Weapon   
│   ├───_StatUpgradeUI   
│   └───_UserIConUI   
└───Utils   



## Trouble Shooting
- BigIntegerToUnit 기능   
  - 스크립트를 가져와 큰 수를 표현할 수 있는데 BigInteger에서 Unit단위로 바꿔주는 기능이 없어서 직접 구현해야했다.   
  - 1000단위로 나눠서 단위별로 만들어줘야하고 자릿수는 소숫점 첫째짜리까지 보통 나타내기 때문에 그렇게 구현하려고했다.   
  - 처음에는 Log10을이용해서 자릿수를 떙겨와서 하려했지만 실패했고 다른 방식을 찾다가 단위를 미리 등록해놓고 이용하는 방식이 보여서 채택했다.      
  - 단위 Unit을 미리 리스트로 만들어놓고 ToString()을 이용해 int단위만큼 잘라주고 뒤에 Unit을 붙혀주고 리턴하는 방식으로 해결했다.
    
- 방치형에서 항상있는 Inventory에서 일괄합성 기능
  - 이것도 고민을 엄청 많이 했는데 생각외로 간단하게 구현했다.
  - Slot들을 다 가지고 있고 해당 슬롯에 Quantity 데이터를 ScriptableObject에 부여해서
  - 합성에 필요한 갯수를 가지고있는 슬롯들만 합성해주는 방식을 이용했다.
  - Quantity를 합성에 필요한 갯수로 나눠 몫/나머지 를 구하고 나머지는 해당 슬롯에 분배하고 몫은 다음 랭크의 갯수에 분배하여 구현하였다.
 
- Character Stat변화
  - UIClick을 통해 Character Stat을 변화시키는 방식인데
  - 직접 캐릭터 데이터에 접근해서 데이터를 바꾸는 방식으로 구현했다.
  - 변화 시킨 양을 또 따로 저장하고 싶어서 (나중에 코드확장할 때 유용하게 쓰일 것 같아서)   
  - 변화 시킨 양만큼의 데이터들을 따로 저장하는 ScriptableObject를 구현해놓았다.   
