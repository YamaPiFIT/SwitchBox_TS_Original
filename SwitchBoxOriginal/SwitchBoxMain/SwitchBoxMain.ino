////include
#include <Joystick.h>

Joystick_ Joystick;

/*
　マトリックスで使用しているピン番号を設定
*/
const int matrixPinInputNo[] = {2,3,4,5};
const int matrixPinOutputNo[] = {6,7,8,9,10,11,12};
//const int analogPinInputNo[] ={A0,A1};

/*
　配列のサイズ
*/
const int matrixPinInputNoSize = sizeof(matrixPinInputNo) / sizeof(int);
const int matrixPinOutputNoSize = sizeof(matrixPinOutputNo) / sizeof(int);
//const int analogPinInputNoSize = sizeof(analogPinInputNo) / sizeof(int);
const int matrixPinMaxCount = matrixPinInputNoSize + matrixPinOutputNoSize;

/*
　マトリックスで押された情報を保存する
　[出力先][入力先]
*/
boolean matrixState [matrixPinOutputNoSize][matrixPinInputNoSize] = {};

/*
  ボタン番号(Windowsで認識されるボタンNoと紐ついている)
*/
int buttonNo = 0;

/*
  シリアルデータ受信用変数
*/
int testPosX = 0;

void setup() {
  initialize();
  initializePublicVariable();
}

void loop() {
  // put your main code here, to run repeatedly:
  buttonNo = 0;
  readMatrixPin();
}

/*
    初期化
*/
void initializePublicVariable(){
  buttonNo = 0;
  testPosX = 0;
}

/*
    初期化
*/
void initialize(){
  /*
    ピンが受信か送信かを設定
  */
  //matrix input setup
  for(int i = 0; i < matrixPinInputNoSize; i++){
    //pinMode(matrixPinInputNo[i], INPUT);
    pinMode(matrixPinInputNo[i], INPUT_PULLUP);
  }
  //matrix output set
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    pinMode(matrixPinOutputNo[i], OUTPUT);
  }
  
  //analog stick input set
  /*
  for(int i=0; i < analogPinInputNoSize; i++){
    pinMode(analogPinInputNo[i], INPUT);
  }
  */
    
  // Set Range Values
  Joystick.setXAxisRange(-1024, 1024);
  Joystick.setYAxisRange(-1024, 1024);
  Joystick.setZAxisRange(0, 256);
  Joystick.setRxAxisRange(0, 360);
  Joystick.setRyAxisRange(0, 360);
  Joystick.setRzAxisRange(0, 720);
  Joystick.setThrottleRange(0, 255);
  Joystick.setRudderRange(0, 255);

  // Initialize Joystick Library
  Joystick.begin();
}

/*
  ピンのステータス取得（メッセージver)
*/
void outputPinStatusMessage(int _pinNo, String _pinNmae){
  boolean _pinStatus;
  _pinStatus = digitalRead(_pinNo);
  Serial.println( _pinNmae + " pin status : " + String(_pinStatus));
}

/*
　ピンのステータス取得
*/
boolean outputMatrixPinStatus(int _pinNo){
  boolean _pinStatus;
  _pinStatus = digitalRead(_pinNo);
  return !_pinStatus;
}

boolean outputPinStatus(int _pinNo){
  boolean _pinStatus;
  _pinStatus = !digitalRead(_pinNo);
  return _pinStatus;
}

/*
  マトリクスのピンが反転処理が必要かどうかを調べ、必要なら反転させる
*/
void checkMatrixPinStatus(int j){
  int _ans = 0;
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    _ans += matrixState[i][j];
  }

  if(_ans > 0){
    for(int i = 0; i < matrixPinOutputNoSize; i++){
       matrixState[i][j] = !matrixState[i][j];
    }
  }  
}

/*
  マトリックスのピン情報を取得する
*/
void readMatrixPin(){

  //最初にすべての電源をOFFにする
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    // 処理対象OUTのPINをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

  //Serial.println("[OUTPUT Pin No.] - [INPUT Pin No.]");
  //matrix output set
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    //処理対象のOUTPUTをONにする
    digitalWrite(matrixPinOutputNo[i], HIGH);
    //何を押されているかをチェックする(i行目のチェック)
    for(int j = 0; j < matrixPinInputNoSize; j++){
      matrixState[i][j] = outputMatrixPinStatus(matrixPinInputNo[j]);
    }
    
    // 処理対象のOUTPUTをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

  //最初にすべての電源をOFFにする
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    // 処理対象OUTのPINをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

  //反転処理が必要かどうかを調べる
  for(int j = 0; j < matrixPinInputNoSize; j++){
    checkMatrixPinStatus(j);
  }

  //デバックログ＆ボタンを設定する
  //ボタン番号(Windowsで認識されるボタンNoと紐ついている)
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    for(int j = 0; j < matrixPinInputNoSize; j++){
      Joystick.setButton(buttonNo, matrixState[i][j]);
      buttonNo++;
    }
  }
}