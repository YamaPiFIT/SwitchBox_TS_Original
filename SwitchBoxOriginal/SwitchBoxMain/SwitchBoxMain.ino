
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
const int matrixPinInputNo[] = {4,5,6,7};
const int matrixPinOutputNo[] = {0,1,2,3};

/*
　マトリックスで押された情報を保存する
　[出力先][入力先]
*/
boolean matrixState [sizeof(matrixPinOutputNo)][sizeof(matrixPinInputNo)] = {};

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


  sendStartMessage("Loop Method Strat");
}

/*
    初期化
*/
void initialize(){
  
  /*
    ピンが受信か送信かを設定
  */
  //pinMode(switchPinOne, INPUT);
  //pinMode(switvhPinTow, OUTPUT);


  //matrix input setup
  for(int i = sizeof(matrixPinInputNo); i < sizeof(matrixPinInputNo); i++){
    pinMode(matrixPinInputNo[i], INPUT);
  }
  //matrix output set
  for(int i = sizeof(matrixPinOutputNo); i < sizeof(matrixPinOutputNo); i++){
    pinMode(matrixPinOutputNo[i], OUTPUT);
  }
  

}

void loop() {
  // put your main code here, to run repeatedly:

  sendStartMessage("Switch Status start");

  //outputPinStatusMessage(switchPinOne,"switchPinOne");
  //outputPinStatusMessage(switvhPinTow,"switvhPinTow");
  
  readMatrixPin();


  sendStartMessage("Switch Status End");
  delay(1000);//1000msec待機(1秒待機)
}


/*
    開始のメッセージ送信（デバッグ用）
*/
void sendStartMessage(String _message){
  if(debug == true){
    Serial.println("----------------- " + _message + " -----------------" );
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
int readMatrixPin(){

  //最初にすべての電源をOFFにする
  for(int i = sizeof(matrixPinOutputNo); i < sizeof(matrixPinOutputNo); i++){
    // 処理対象OUTのPINをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

  //matrix output set
  for(int i = sizeof(matrixPinOutputNo); i < sizeof(matrixPinOutputNo); i++){
    //処理対象のOUTPUTをONにする
    digitalWrite(matrixPinOutputNo[i], HIGH);

    //何を押されているかをチェックする(i行目のチェック)
    for(int j = sizeof(matrixPinInputNo); j < sizeof(matrixPinInputNo); j++){
      matrixState[i][j] = outputMatrixPinStatus(matrixPinInputNo[j]);
      outputPinStatusMessage(matrixState[i][j],"matrixState["+i+"]["+j"]");
    }
    
    // 処理対象OUTのPINをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

  //最初にすべての電源をOFFにする
  for(int i = sizeof(matrixPinOutputNo); i < sizeof(matrixPinOutputNo); i++){
    // 処理対象OUTのPINをLOWにする
    digitalWrite(matrixPinOutputNo[i], LOW);
  }

}
