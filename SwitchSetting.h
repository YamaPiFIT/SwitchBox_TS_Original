/*
 * スイッチ設定
 * 
 * スイッチ、キーパット、ロータリエンコーダの数、使用するPINの設定を行う
 */

/* 
 * PIN設定
 */
// スイッチ
const byte PIN_SW_0 = -1;     // 設定なしのためダミー値
const byte PIN_SW_1 = -1;     // 設定なしのためダミー値
// マトリクススイッチ
const byte PIN_MAT_IN_0 = 1;  // 基板上はTX0 
const byte PIN_MAT_IN_1 = 0;  // 基板上はRX1
const byte PIN_MAT_IN_2 = 16; // 基板上は16
const byte PIN_MAT_IN_3 = 10; // 基板上は10
const byte PIN_MAT_IN_4 = 4;  // 基板上は4
const byte PIN_MAT_OUT_0 = 5; // 基板上は5
const byte PIN_MAT_OUT_1 = 6; // 基板上は6
const byte PIN_MAT_OUT_2 = 7; // 基板上は7
const byte PIN_MAT_OUT_3 = 8; // 基板上は8
const byte PIN_MAT_OUT_4 = 9; // 基板上は9
// ロータリエンコーダ
const byte PIN_ENC_A_0 = 20;  // 基板上はA2
const byte PIN_ENC_A_1 = 21;  // 基板上はA3
const byte PIN_ENC_B_0 = 18;  // 基板上はA0
const byte PIN_ENC_B_1 = 19;  // 基板上はA1
const byte PIN_ENC_C_0 = 14;  // 基板上は14
const byte PIN_ENC_C_1 = 15;  // 基板上は15
const byte PIN_ENC_D_0 = 2;   // 基板上は2
const byte PIN_ENC_D_1 = 3;   // 基板上は3

/* 
 * スイッチ設定
 */
const byte SWITCH_COUNT = 0;              // スイッチ数
const byte switchPins[SWITCH_COUNT] = {   // スイッチPIN設定
  };

/* 
 * マトリクススイッチ設定
 */
const byte COLS = 5;                      // マトリクススイッチ列数
const byte ROWS = 5;                      // マトリクススイッチ行数  
const byte outPins[ROWS] = {              // マトリクススイッチ行PIN設定
  PIN_MAT_OUT_0, 
  PIN_MAT_OUT_1, 
  PIN_MAT_OUT_2, 
  PIN_MAT_OUT_3, 
  PIN_MAT_OUT_4
  };
const byte inPins[COLS] = {               // マトリクススイッチ列PIN設定
  PIN_MAT_IN_0,
  PIN_MAT_IN_1,
  PIN_MAT_IN_2,
  PIN_MAT_IN_3,
  PIN_MAT_IN_4
  };

/* 
 * ロータリエンコーダ設定
 */
const byte ROTARY_ENCODER_COUNT = 4;       // ロータリーエンコーダ数
const byte rotaryEncoderPins[ROTARY_ENCODER_COUNT][2] = {   // ロータリーエンコーダPIN設定
  { PIN_ENC_A_0, PIN_ENC_A_1 },
  { PIN_ENC_B_0, PIN_ENC_B_1 },
  { PIN_ENC_C_0, PIN_ENC_C_1 },
  { PIN_ENC_D_0, PIN_ENC_D_1 }
  };
