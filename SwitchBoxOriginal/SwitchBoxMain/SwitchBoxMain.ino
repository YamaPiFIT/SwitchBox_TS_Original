
//Const
const boolean debug = true;// デバッグ用フラグ
/*
 ピンの番号を設定
*/
//const int switchPinOne = 0;
//const int switvhPinTow = 10;

/*
　マトリックスで使用しているピン番号を設定
*/
//const int matrixPinInputNo[] = {4,5,6,7};
//const int matrixPinOutputNo[] = {0,1,2,3};
const int matrixPinInputNo[] = {0,1,2,3};
const int matrixPinOutputNo[] = {4,5,6,7};
/*
  ロータリーエンコーダーで使用しているピン番号を設定
*/
const int rotaryEncoderInputNo[] = {8,9,10,11,12,13,19,20,21,22,23,24};

/*
　配列のサイズ
*/
const int matrixPinInputNoSize = sizeof(matrixPinInputNo) / sizeof(int);
const int matrixPinOutputNoSize = sizeof(matrixPinOutputNo) / sizeof(int);
const int rotaryEncoderInputNoSize = sizeof(rotaryEncoderInputNo) / sizeof(int);

/*
　マトリックスで押された情報を保存する
　[出力先][入力先]
*/
boolean matrixState [matrixPinOutputNoSize][matrixPinInputNoSize] = {};
/*
　ロータリーエンコーダーの情報を保存する
  [入力先]
*/
boolean rotaryEncoderState [rotaryEncoderInputNoSize] = {};

void setup() {
  // put your setup code here, to run once:

  // シリアル開始（デバックの場合）
  if (debug == true) {
    Serial.begin(9600);
  }

  // シリアル開始の準備が整うまでここで処理を止める。
  while( !Serial ) {
  }

  //初期化
  sendStartMessage("Initialize Strat");
  initialize();
  sendStartMessage("Initialize End");
}

/*
    初期化
*/
void initialize(){
  
  /*
    ピンが受信か送信かを設定
  */
  //matrix input setup
  sendMessage("matrix input setup start"); 
  for(int i = 0; i < matrixPinInputNoSize; i++){
    pinMode(matrixPinInputNo[i], INPUT);
  }
  //matrix output set
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    pinMode(matrixPinOutputNo[i], OUTPUT);
  }
  //RotaryEncoder intput set
  for(int i = 0; i < rotaryEncoderInputNoSize; i++){
    pinMode(rotaryEncoderInputNo[i], INPUT);
  }
  sendMessage("matrix input setup end");

}

void loop() {
  // put your main code here, to run repeatedly:
  sendStartMessage("Loop Method Strat");
  
  readMatrixPin();
  readRotaryEncoder();

  sendStartMessage("Loop Method End");
    // シリアル開始（デバックの場合）
  if (debug == true) {
    delay(1000);//1000msec待機(1秒待機)
  }
}


/*
    開始のメッセージ送信（デバッグ用）
*/
void sendStartMessage(String _message){
  if(debug == true){
    Serial.println("----------------- " + _message + " -----------------" );
  }
}

void sendMessage(String _message){
  if(debug == true){
    Serial.println(_message);
  }
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
  return _pinStatus;
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

  Serial.println("[OUTPUT] - [INPUT]");
  //matrix output set
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    //処理対象のOUTPUTをONにする
    digitalWrite(matrixPinOutputNo[i], HIGH);
    //何を押されているかをチェックする(i行目のチェック)
    for(int j = 0; j < matrixPinInputNoSize; j++){
      matrixState[i][j] = outputMatrixPinStatus(matrixPinInputNo[j]);
      Serial.println(" pin status ["+String(matrixPinOutputNo[i])+"]["+String(matrixPinInputNo[j])+"] : " + String(matrixState[i][j]));
    }
    
    // 処理対象のOUTPUTをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

  //最初にすべての電源をOFFにする
  for(int i = 0; i < matrixPinOutputNoSize; i++){
    // 処理対象OUTのPINをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }
}

/*
  ロータリーエンコーダーの読み取り
*/
void readRotaryEncoder(){
  for(int i = 0; i < rotaryEncoderInputNoSize; i++){
      rotaryEncoderState[i] = outputMatrixPinStatus(rotaryEncoderInputNo[i]);
      Serial.println(" pin status ["+String(rotaryEncoderInputNo[i])+"] : " + String(rotaryEncoderState[i]));
    }
}

