
const boolean debug = true;// デバッグ用フラグ
const int switchPin = 0;//タクトスイッチを接続するピン



void setup() {
  // put your setup code here, to run once:

  // シリアル開始（デバックの場合）
  if (debug) {
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
  //デジタル0番ピンを入力用として設定
  pinMode(switchPin, INPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  boolean input;

  input = digitalRead(switchPin);//0番ピン(スイッチ)の入力状態をinputに代入
  Serial.println(input);//「input」を送信、改行
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
