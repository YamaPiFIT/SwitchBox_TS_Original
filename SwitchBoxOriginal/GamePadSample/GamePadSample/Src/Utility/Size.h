/**
* @file Size.h
* @brief データのサイズ(横、縦)を保存できる構造体の宣言
*/
#ifndef SIZE_H_
#define SIZE_H_

//=====================================================================//
//! サイズデータ用構造体
//=====================================================================//
struct Size
{
	/** Constructor */
	Size()
	{
		Width = 0.0f;
		Height = 0.0f;
	}

	/**
	* @brief Constructor
	* @param[in] width 横幅
	* @param[in] height 縦幅
	*/
	Size(float width, float height)
	{
		Width = width;
		Height = height;
	}

	/**
	* @brief Constructor
	* @param[in] size コピー用サイズデータ
	*/
	Size(const Size& size)
	{
		this->Width = size.Width;
		this->Height = size.Height;
	}

	float Width;		//!< 横幅
	float Height;		//!< 縦幅
};

#endif
