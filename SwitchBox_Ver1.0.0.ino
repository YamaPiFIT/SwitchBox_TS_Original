//
// スイッチボックス Ver 1.0.0
//
// for Arduino Leonardo
//
//　2021.11.08 H.Tanaka
//


#include <Keyboard.h>
/*
  #include <Joystick.h>
*/
#include "SwitchSetting.h"
#include "OutPutSetting.h"

const boolean debug = true;          // デバッグ用フラグ

/*
Joystick_ joystick1 = Joystick_(      // ジョイスティック1設定
                        joystick1HidReportId,
                        JOYSTICK_TYPE_GAMEPAD,
                        28,
                        1,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false
                      );
Joystick_ joystick2 = Joystick_(      // ジョイスティック2設定
                        joystick2HidReportId,
                        JOYSTICK_TYPE_GAMEPAD,
                        28,
                        1,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false,
                        false
                      );
*/

byte switchLastState[SWITCH_COUNT] = {};   // 前回読み取り時のスイッチの値

byte matrixState[ROWS][COLS] = {};         // 読み取ったマトリクススイッチの値
byte matrixLastState[ROWS][COLS] = {};     // 前回読み取り時のマトリクススイッチの値
byte targetRowNum = 0;                     // マトリクススイッチ読み取り処理対象行番号
byte buttonCount = 0;                      // マトリクススイッチ押されたボタンの数
unsigned long previousMillis = 0;         // マトリクススイッチ読み取り間隔制御用

byte rotaryEncoderPos[ROTARY_ENCODER_COUNT] = {}; // ロータリーエンコーダの値

/*
   初期化
*/
void setup() {
  // シリアル開始（デバックの場合）
  if (debug) {
    Serial.begin(9600);
  }

  // 配列初期化
  if (SWITCH_COUNT != 0) {
    switchLastState[SWITCH_COUNT] = {0};
  }
  if (ROWS != 0 && COLS != 0) {
    matrixState[ROWS][COLS] = {0};
    matrixLastState[ROWS][COLS] = {0};
  }
  if (ROTARY_ENCODER_COUNT != 0) {
    rotaryEncoderPos[ROTARY_ENCODER_COUNT] = {0};
  }

  // スイッチPIN初期化
  for (byte no = 0; no < SWITCH_COUNT; no++) {
    pinMode(switchPins[no], INPUT_PULLUP);
  }
  // マトリクスPIN初期化
  // OUT
  for (byte rowNum = 0; rowNum < ROWS; rowNum++) {
    pinMode(outPins[rowNum], OUTPUT);
    digitalWrite(outPins[rowNum], HIGH);
  }
  // IN
  for (byte conNum = 0; conNum < COLS; conNum++) {
    pinMode(inPins[conNum], INPUT_PULLUP);
  }
  // ロータリエンコーダPIN初期化
  for (byte no = 0; no < ROTARY_ENCODER_COUNT; no++) {
    pinMode(rotaryEncoderPins[no][0], INPUT_PULLUP);
    pinMode(rotaryEncoderPins[no][1], INPUT_PULLUP);
  }

  // スイッチ初期値取得
  for (byte no = 0; no < SWITCH_COUNT; no++) {
    switchLastState[no] = digitalRead(switchPins[no]);
  }

  // マトリクススイッチ初期値取得
  for (byte rowNum = 0; rowNum < ROWS; rowNum++) {
    readMatrix(1);
  }

  /*
  // ジョイスティック初期化
  joystick1.setHatSwitch(0, -1);
  joystick2.setHatSwitch(0, -1);

  // ジョイスティック開始
  joystick1.begin();
  joystick2.begin();
  */

  // キーボード開始
  //Keyboard.begin();
}

/*
   ループ
*/
void loop() {

  Serial.println("--------------LOG START--------------");

  // スイッチ読み取り
  for (byte no = 0; no < SWITCH_COUNT; no++) {
    readSwitch(no);
  }

  // マトリクス読み取り
  readMatrix(0);

  // ロータリエンコーダ読み取り
  /*
  for (byte no = 0; no < ROTARY_ENCODER_COUNT; no++) {
    readRotaryEncoder(no);
  }
  */

    Serial.println("--------------LOG END--------------");
    Serial.println();

}

/*
   スイッチ読み込み

*/
void readSwitch(byte no) {
  int state = digitalRead(switchPins[no]);

  /*
  // ONになった時 1(HIGH) -> 0(LOW)
  if (switchLastState[no] - state == 1) {
    outPut(swOnOutPut[no]);
  }
  // OFFになった時 0(LOW) -> 1(HIGH)
  if (switchLastState[no] - state == -1) {
    outPut(swOffOutPut[no]);
  }
  */

  switchLastState[no] = state;
}

/*
   マトリクス読み取り
*/
void readMatrix(int init) {
  unsigned long currentMillis = millis();

  if (currentMillis - previousMillis >= 15) {
    previousMillis = currentMillis;

    // 処理対象OUTのPINをLOWにする
    digitalWrite(outPins[targetRowNum], LOW);

    for (byte colNum = 0; colNum < COLS; colNum++) {
      // 対象ROWのPIN状態を取得
      matrixState[targetRowNum][colNum] = digitalRead(inPins[colNum]);
    }

    // 処理対象OUTのPINをHIGHに戻す
    digitalWrite(outPins[targetRowNum], HIGH);

    targetRowNum++;
  }

  // マトリクススイッチの状態を全て取得できたら出力する
  if (targetRowNum == ROWS) {
    /*
    if (init == 0) {
      for (byte rowNum = 0; rowNum < ROWS; rowNum++) {
        for (byte colNum = 0; colNum < COLS; colNum++) {
          // ONになった時 1(HIGH) -> 0(LOW)
          if (matrixLastState[rowNum][colNum] - matrixState[rowNum][colNum] == 1) {
            outPut(matrixOnOutPut[rowNum][colNum]);
          }
          // OFFになった時 0(LOW) -> 1(HIGH)
          if (matrixLastState[rowNum][colNum] - matrixState[rowNum][colNum] == -1) {
            outPut(matrixOffOutPut[rowNum][colNum]);
          }
        }
      }
    }
    */

    // LastStateを保存
    for (byte rowNum = 0; rowNum < ROWS; rowNum++) {
      for (byte colNum = 0; colNum < COLS; colNum++) {
        matrixLastState[rowNum][colNum] = matrixState[rowNum][colNum];    // LastStateを保存
      }
    }

    targetRowNum = 0;
    buttonCount = 0;

    // デバッグ出力
    if (debug) {
      //Serial.println(SWITCH_COUNT);
      for (int rowNum = 0; rowNum < ROWS; rowNum++) {
        for (int colNum = 0; colNum < COLS; colNum++) {
          Serial.print(matrixState[rowNum][colNum]);
        }
        Serial.println();
      }
      Serial.println();
      Serial.println();
    }
  }
}

/*
   ロータリエンコーダ読み込み
*/
void readRotaryEncoder(int no) {
  byte cur = (!digitalRead(rotaryEncoderPins[no][0]) << 1) + !digitalRead(rotaryEncoderPins[no][1]);
  byte old = rotaryEncoderPos[no] & B00000011;
  byte dir = (rotaryEncoderPos[no] & B00110000) >> 4;

  // 10進数の並び方が0-1-3-2となるのを0-1-2-3に変換
  if (cur == 3) {
    cur = 2;
  }
  else if (cur == 2) {
    cur = 3;
  }

  if (cur != old) {
    if (dir == 0) {
      if (cur == 1 || cur == 3) {
        dir = cur;
      }
    } else {
      if (cur == 0) {
        if (dir == 1 && old == 3) {
          // 右回り
          outPut(rotaryEncoderOutPut[no][1]);
        }
        else if (dir == 3 && old == 1) {
          // 左回り
          outPut(rotaryEncoderOutPut[no][0]);
        }
        dir = 0;
      }
    }
    rotaryEncoderPos[no] = (dir << 4) + (old << 2) + cur;

  }
}

/*
   出力

   ジョイスティック、キーボードに出力
*/
void outPut(String val) {

  // デバッグ出力
  if (debug) {
    Serial.println(val);
  }

  if (val != "") {
    String vals[3] = {"\0"};
    split(val, '-', vals);
    Serial.println(vals[0]);
    Serial.println(vals[1]);
    /*
    if (vals[0] == "J1") {
      outPutJoystick(joystick1, vals[1], vals[2]);
    }
    else if (vals[0] == "J2") {
      outPutJoystick(joystick2, vals[1], vals[2]);
    }
    else if (vals[0] == "K") {
      if (vals[2] == "P") {
        Keyboard.releaseAll();

        if (vals[1].toInt() == 1) keyPress(key0, sizeof(key0));
        else if (vals[1].toInt() == 2) keyPress(key1, sizeof(key1));
        else if (vals[1].toInt() == 3) keyPress(key2, sizeof(key2));
        else if (vals[1].toInt() == 4) keyPress(key3, sizeof(key3));
        else if (vals[1].toInt() == 5) keyPress(key4, sizeof(key4));
        else if (vals[1].toInt() == 6) keyPress(key5, sizeof(key5));
        else if (vals[1].toInt() == 7) keyPress(key6, sizeof(key6));
      }
      else if (vals[2] == "R") {
        Keyboard.releaseAll();
      }
      else if (vals[2] == "PR") {
        Keyboard.releaseAll();

        if (vals[1].toInt() == 1) keyPress(key0, sizeof(key0));
        else if (vals[1].toInt() == 2) keyPress(key1, sizeof(key1));
        else if (vals[1].toInt() == 3) keyPress(key2, sizeof(key2));
        else if (vals[1].toInt() == 4) keyPress(key3, sizeof(key3));
        else if (vals[1].toInt() == 5) keyPress(key4, sizeof(key4));
        else if (vals[1].toInt() == 6) keyPress(key5, sizeof(key5));
        else if (vals[1].toInt() == 7) keyPress(key6, sizeof(key6));

        delay(40);

        Keyboard.releaseAll();
      }
      */
      if (vals[0] == "K") {
        if (vals[2] == "P") {
            /*
            Keyboard.releaseAll();
            if (vals[1].toInt() == 1) keyPress(key0, sizeof(key0));
            else if (vals[1].toInt() == 2) keyPress(key1, sizeof(key1));
            else if (vals[1].toInt() == 3) keyPress(key2, sizeof(key2));
            else if (vals[1].toInt() == 4) keyPress(key3, sizeof(key3));
            else if (vals[1].toInt() == 5) keyPress(key4, sizeof(key4));
            else if (vals[1].toInt() == 6) keyPress(key5, sizeof(key5));
            else if (vals[1].toInt() == 7) keyPress(key6, sizeof(key6));
            */
        }
        else if (vals[2] == "R") {
          //Keyboard.releaseAll();
        }
        else if (vals[2] == "PR") {
            /*
            Keyboard.releaseAll();
            if (vals[1].toInt() == 1) keyPress(key0, sizeof(key0));
            else if (vals[1].toInt() == 2) keyPress(key1, sizeof(key1));
            else if (vals[1].toInt() == 3) keyPress(key2, sizeof(key2));
            else if (vals[1].toInt() == 4) keyPress(key3, sizeof(key3));
            else if (vals[1].toInt() == 5) keyPress(key4, sizeof(key4));
            else if (vals[1].toInt() == 6) keyPress(key5, sizeof(key5));
            else if (vals[1].toInt() == 7) keyPress(key6, sizeof(key6));
            */
            delay(40);

            //Keyboard.releaseAll();
          }
    }
    else if (vals[0] == "M") {

      byte datalength = message[vals[1].toInt() - 1].length();

      for (byte i = 0; i < datalength; i++) {
        //Keyboard.print(message[vals[1].toInt() - 1].charAt(i));
        delay(20);  
      }
      
    //Keyboard.print(message[vals[1].toInt() - 1]);
    }
  }
}

/*
   キーPress
*/
/*
void keyPress(byte *k, byte size) {
  for (byte c = 0; c < size; c++) {
    Keyboard.press(*k++);
  }
}
*/

/*
   ジョイスティック出力
*/
/*
void outPutJoystick(Joystick_ joystick, String val, String mode) {

  if (mode == "P") {
    if (val == "L") {
      joystick.setHatSwitch(0, 270);
    }
    else if (val == "R") {
      joystick.setHatSwitch(0, 90);
    }
    else if (val == "U") {
      joystick.setHatSwitch(0, 0);
    }
    else if (val == "D") {
      joystick.setHatSwitch(0, 180);
    }
    else {
      joystick.setButton(val.toInt() - 1, 1);
    }
  }
  else if (mode == "R") {
    if (val == "L") {
      joystick.setHatSwitch(0, -1);
    }
    else if (val == "R") {
      joystick.setHatSwitch(0, -1);
    }
    else if (val == "U") {
      joystick.setHatSwitch(0, -1);
    }
    else if (val == "D") {
      joystick.setHatSwitch(0, -1);
    }
    else {
      joystick.setButton(val.toInt() - 1, 0);
    }
  }
  else if (mode == "PR") {
    joystick.setButton(val.toInt() - 1, 1);
    delay(50);
    joystick.setButton(val.toInt() - 1, 0);
  }
}
*/

/*
   文字分割
*/
byte split(String data, char delimiter, String *dst) {
  byte index = 0;
  byte arraySize = (sizeof(data) / sizeof((data)[0]));
  byte datalength = data.length();

  for (byte i = 0; i < datalength; i++) {
    char tmp = data.charAt(i);
    if ( tmp == delimiter ) {
      index++;
      if ( index > (arraySize - 1)) return -1;
    }
    else dst[index] += tmp;

  }
  return (index + 1);
}
