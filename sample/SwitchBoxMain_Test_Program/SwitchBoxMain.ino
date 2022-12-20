
const boolean debug = true;// デバッグ用フラグ

/*
 ピンの番号を設定
*/
const int switchPinOne = 0;
const int switvhPinTow = 10;



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
  pinMode(switchPinOne, INPUT);
  pinMode(switvhPinTow, OUTPUT);

}

void loop() {
  // put your main code here, to run repeatedly:

  sendStartMessage("Switch Status start");

  outputPinStatusMessage(switchPinOne,"switchPinOne");
  outputPinStatusMessage(switvhPinTow,"switvhPinTow");

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
    ピンのステータス取得
*/
void outputPinStatusMessage(int _pinNo, String _pinNmae){
  boolean _pinStatus;
  _pinStatus = digitalRead(_pinNo);
  Serial.println( _pinNmae + " pin status : " + String(_pinStatus));
}
