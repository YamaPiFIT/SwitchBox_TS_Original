
const boolean debug = true;// デバッグ用フラグ
const int switchPinOne = 0;//タクトスイッチを接続するピン
const int switvhPinTow = 10;



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


  sendStartMessage("Loop Method Strat");
}

/*
    初期化
*/
void initialize(){
  //デジタル0番ピンを入力用として設定
  pinMode(switchPinOne, INPUT);
  pinMode(switvhPinTow,OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  boolean inputOne;
  boolean outputOne;

  inputOne = digitalRead(switchPinOne);//スイッチの入力状態をinputに代入
  outputOne = digitalRead(switvhPinTow);
  Serial.println("input pin status : " + String(inputOne));//「input」を送信、改行
  Serial.println("output pin status : " + String(outputOne));
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
