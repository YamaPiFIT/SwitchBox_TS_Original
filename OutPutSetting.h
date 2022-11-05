/*
 * 出力設定
 * 
 */

/* 
 * ジョイスティック 
 */
const byte joystick1HidReportId = 0x04;   // ジョイスティック1 Hid Report Id
const byte joystick2HidReportId = 0x05;   // ジョイスティック2 Hid Report Id

/* 
 * キー
 * 
 * Push,Releaseを行うキー設定
 * 
 * 例えば「s」キーを登録すると
 * 1.ボタンを押したときにキーボードの「s」キーをPush
 * 2.ボタンを押した状態を保持すると「s」キーのPush状態を保持
 * 3.ボタンを離すとキーボードの「s」キーをRelease
 * という動作になり、エンジンスタートで使用することができる。
 * 他に「esc」キーを登録すると走行画面からexitできる。
 * 
 * キーは複数登録でき、「ctrl」「alt」「delete」の3つを登録すると
 * 3つのキーが同時に押すことになる。
 * 
 * キー1つの場合
 * const byte key0[] {'s'};
 * 複数キー同時押しの場合
 * const byte key0[] {KEY_RIGHT_CTRL, KEY_LEFT_ALT, KEY_DELETE};
 * 
 * 16種類のキーを登録可能
 */
byte key0[] {'s'};              // キー番号1番
byte key1[] {'i'};              // キー番号2番
/*
byte key2[] {KEY_LEFT_ALT,'['}; // キー番号3番
byte key3[] {KEY_LEFT_ALT,']'}; // キー番号4番
byte key4[] {KEY_ESC};          // キー番号5番
byte key5[] {KEY_ESC};          // キー番号6番
byte key6[] {KEY_ESC};          // キー番号7番
byte key7[] {KEY_ESC};          // キー番号8番
byte key8[] {KEY_ESC};          // キー番号9番
byte key9[] {KEY_ESC};          // キー番号10番
byte key10[] {KEY_ESC};         // キー番号11番
byte key11[] {KEY_ESC};         // キー番号12番
byte key12[] {KEY_ESC};         // キー番号13番
byte key13[] {KEY_ESC};         // キー番号14番
byte key14[] {KEY_ESC};         // キー番号15番
byte key15[] {KEY_ESC};         // キー番号16番
*/

/* 
 * メッセージ
 * 
 * キーボード入力される文字列を設定
 * 
 * 例えば「tOK!\n」という文字列を登録すると
 * ボタンを押したときにキーボードから「t」「O」「K」「!」「enter」と順番に入力され
 * iRacingの走行中に「OK!」というメッセージが表示される。
 * 
 * 8種類のメッセージを登録可能
 */
String message[16] = {
  "tKonnichiwa!\n", // メッセージ番号1番
  "tKonbanwa!\n",   // メッセージ番号2番
  "tThanks!\n",     // メッセージ番号3番
  "tSorry!\n",      // メッセージ番号4番
  "tOK!\n",         // メッセージ番号5番
  "",               // メッセージ番号6番
  "",               // メッセージ番号7番
  ""               // メッセージ番号8番
  };

/* 
 * 出力設定
 * 
 * 各スイッチ動作時の出力を設定。
 * 
 * [識別子]-[種別]-[動作]
 * 
 * という書式で設定する。
 * 
 *　識別子
 *   K:キー
 *   M:メッセージ   
 *   J1:ジョイスティック1
 *   J2:ジョイスティック2
 *  種別
 *   キーの場合:キー番号(1～16)
 *   メッセージの場合:メッセージ番号(1～16)
 *   ジョイスティックの場合:ボタン番号(1～32)
 *  動作(識別子K,J1,J2で有効)
 *   P:Push(押した状態を保持)
 *   R:Release(離した状態を保持)
 *   PR:Push-Detay-Release(押す-40msec-離す)
 *
 * 例
 *  キー1を押す場合・・・K-1-P
 *  キー1を離す場合・・・K-1-R
 *  メッセージ1番の場合・・・M-1
 *  ジョイスティック1のボタン1を押す場合・・・J1-1-P
 *  ジョイスティック1のボタン1を離す場合・・・J1-1-R
 * 
 */

/*
 * スイッチがONになたっとときの出力設定
 * 
 * 設定なし
 */
const String swOnOutPut[SWITCH_COUNT] = {
  };

/*
 * スイッチがOFFになたっとときの出力設定
 * 
 * 設定なし
 */
const String swOffOutPut[SWITCH_COUNT] = {
  };

/*
 * マトリクススイッチがONになたっとときの出力設定
 */
const String matrixOnOutPut[ROWS][COLS] = {
    { "K-1-P",    "J1-1-P",   "J1-3-P",   "J1-5-P",   "J1-7-P"   }, // スイッチ1,  スイッチ2,  スイッチ3,  スイッチ4,  スイッチ5
    { "J1-18-PR", "J1-2-P",   "J1-4-P",   "J1-6-P",   "J1-8-P"   }, // スイッチ6,  スイッチ7,  スイッチ8,  スイッチ9,  スイッチ10
    { "J1-20-PR", "J1-9-P",   "J1-10-P",  "J1-11-P",  "J1-12-P"  }, // スイッチ11, スイッチ12, スイッチ13, スイッチ14, スイッチ15
    { "J1-22-PR", "M-1",      "M-2",      "M-3",      "M-4"      }, // スイッチ16, スイッチ17, スイッチ18, スイッチ19, スイッチ20
    { "",         "J2-9-P",   "J2-10-P",  "J2-11-P",  "J2-12-P"  }  // スイッチ21, スイッチ22, スイッチ23, スイッチ24, スイッチ25
  };

/*
 * マトリクススイッチがOFFになたっとときの出力設定
 */
const String matrixOffOutPut[ROWS][COLS] = {
    { "K-1-R",    "J1-1-R",   "J1-3-R",   "J1-5-R",   "J1-7-R"   }, // スイッチ1,  スイッチ2,  スイッチ3,  スイッチ4,  スイッチ5
    { "J1-19-PR", "J1-2-R",   "J1-4-R",   "J1-6-R",   "J1-8-R"   }, // スイッチ6,  スイッチ7,  スイッチ8,  スイッチ9,  スイッチ10
    { "J1-21-PR", "J1-9-R",   "J1-10-R",  "J1-11-R",  "J1-12-R"  }, // スイッチ11, スイッチ12, スイッチ13, スイッチ14, スイッチ15
    { "J1-23-PR", "",         "",         "",         ""         }, // スイッチ16, スイッチ17, スイッチ18, スイッチ19, スイッチ20
    { "",         "J2-9-R",   "J2-10-R",  "J2-11-R",  "J2-12-R"  }  // スイッチ21, スイッチ22, スイッチ23, スイッチ24, スイッチ25
  };

/*
 * ロータリエンコーダの出力設定
 */
const String rotaryEncoderOutPut[ROTARY_ENCODER_COUNT][2] = {
    { "J2-2-PR",  "J2-1-PR"  }, // ロータリエンコーダ1 左回り,右回り
    { "J2-4-PR",  "J2-3-PR"  }, // ロータリエンコーダ2 左回り,右回り
    { "J2-6-PR",  "J2-5-PR"  }, // ロータリエンコーダ3 左回り,右回り
    { "J2-8-PR",  "J2-7-PR"  }  // ロータリエンコーダ4 左回り,右回り
  };

/*
  ASCII文字コード
  コード 文字
  0x20  SPC（空白文字）
  0x21  !
  0x22  "
  0x23  #
  0x24  $
  0x25  %
  0x26  &
  0x27  '
  0x28  (
  0x29  )
  0x2a  *
  0x2b  +
  0x2c  ,
  0x2d  -
  0x2e  .
  0x2f  /
  0x30  0
  0x31  1
  0x32  2
  0x33  3
  0x34  4
  0x35  5
  0x36  6
  0x37  7
  0x38  8
  0x39  9
  0x3a  :
  0x3b  ;
  0x3c  <
  0x3d  =
  0x3e  >
  0x3f  ?
  0x40  @
  0x41  A
  0x42  B
  0x43  C
  0x44  D
  0x45  E
  0x46  F
  0x47  G
  0x48  H
  0x49  I
  0x4a  J
  0x4b  K
  0x4c  L
  0x4d  M
  0x4e  N
  0x4f  O
  0x50  P
  0x51  Q
  0x52  R
  0x53  S
  0x54  T
  0x23  #
  0x24  $
  0x25  %
  0x26  &
  0x27  '
  0x28  (
  0x29  )
  0x2a  *
  0x2b  +
  0x2c  ,
  0x2d  -
  0x2e  .
  0x2f  /
  0x30  0
  0x31  1
  0x32  2
  0x33  3
  0x34  4
  0x35  5
  0x36  6
  0x37  7
  0x38  8
  0x39  9
  0x3a  :
  0x3b  ;
  0x3c  <
  0x3d  =
  0x3e  >
  0x3f  ?
  0x40  @
  0x41  A
  0x42  B
  0x43  C
  0x44  D
  0x45  E
  0x46  F
  0x47  G
  0x48  H
  0x49  I
  0x4a  J
  0x4b  K
  0x4c  L
  0x4d  M
  0x4e  N
  0x4f  O
  0x50  P
  0x51  Q
  0x52  R
  0x53  S
  0x54  T
  0x55  U
  0x56  V
  0x57  W
  0x58  X
  0x59  Y
  0x5a  Z
  0x5b  [
  0x5c  \
  0x5d  ]
  0x5e  ^
  0x5f  _
  0x60  `
  0x61  a
  0x62  b
  0x63  c
  0x64  d
  0x65  e
  0x66  f
  0x67  g
  0x68  h
  0x69  i
  0x6a  j
  0x6b  k
  0x6c  l
  0x6d  m
  0x6e  n
  0x6f  o
  0x70  p
  0x71  q
  0x72  r
  0x73  s
  0x74  t
  0x75  u
  0x76  v
  0x77  w
  0x78  x
  0x79  y
  0x7a  z
  0x7b  {
  0x7c  |
  0x7d  }
  0x7e  ~
  
  修飾キーのコード
  KEY_LEFT_CTRL
  KEY_LEFT_SHIFT
  KEY_LEFT_ALT
  KEY_LEFT_GUI
  KEY_RIGHT_CTRL
  KEY_RIGHT_SHIFT
  KEY_RIGHT_ALT
  KEY_RIGHT_GUI
  KEY_UP_ARROW
  KEY_DOWN_ARROW
  KEY_LEFT_ARROW
  KEY_RIGHT_ARROW
  KEY_BACKSPACE
  KEY_TAB
  KEY_RETURN
  KEY_ESC
  KEY_INSERT
  KEY_DELETE
  KEY_PAGE_UP
  KEY_PAGE_DOWN
  KEY_HOME
  KEY_END
  KEY_CAPS_LOCK
  KEY_F1
  KEY_F2
  KEY_F3
  KEY_F4
  KEY_F5
  KEY_F6
  KEY_F7
  KEY_F8
  KEY_F9
  KEY_F10
  KEY_F11
  KEY_F12

  
  マトリクススイッチ詳細
 
  スイッチ1 : エンジンスタート
  スイッチ2 : トグルスイッチ1上 
  スイッチ3 : トグルスイッチ2上  
  スイッチ4 : トグルスイッチ3上
  スイッチ5 : トグルスイッチ4上
  スイッチ6 : ミサイルスイッチ1
  スイッチ7 : トグルスイッチ1下 
  スイッチ8 : トグルスイッチ2下  
  スイッチ9 : トグルスイッチ3下
  スイッチ10 : トグルスイッチ4下
  スイッチ11 : ミサイルスイッチ2
  スイッチ12 : 上ボタン1
  スイッチ13 : 上ボタン2
  スイッチ14 : 上ボタン3
  スイッチ15 : 上ボタン4
  スイッチ16 : ミサイルスイッチ3
  スイッチ17 : 下ボタン1 
  スイッチ18 : 下ボタン2
  スイッチ19 : 下ボタン3
  スイッチ20 : 下ボタン4
  スイッチ21 : 設定なし
  スイッチ22 : ロータリエンコーダ1
  スイッチ23 : ロータリエンコーダ2
  スイッチ24 : ロータリエンコーダ3
  スイッチ25 : ロータリエンコーダ4
 */
  
