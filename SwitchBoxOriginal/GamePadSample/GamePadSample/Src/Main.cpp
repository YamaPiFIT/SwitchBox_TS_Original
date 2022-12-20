#include <Windows.h>
#include "Engine/Engine.h"
#include "Engine/Graphics.h"
#include "Texture/Texture.h"
#include "Utility/Vec.h"
#include "Engine/Input.h"

int WINAPI WinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPSTR     lpCmpLine,
	INT       nCmdShow)
{
	// エンジンの初期化
	if (InitEngine(640, 480, "ゲームパッド") == false)
	{
		return 0;
	}

	Vec2 pos = Vec2(0.0f, 0.0f);
	LoadTexture("Res/Enemy.png", TextureList::Enemy);

	while (true)
	{
		bool message_ret = false;
		MSG msg;

		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE))
		{
			if (msg.message == WM_QUIT)
			{
				break;
			}
			else 
			{
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
		}
		else
		{
			UpdateInput();

			float speed = 2.0f;

			if (IsButtonPush(ButtonKind::LeftButton) == true)
			{
				pos.X -= speed;
			}
			else if (IsButtonPush(ButtonKind::RightButton) == true)
			{
				pos.X += speed;
			}
			if (IsButtonPush(ButtonKind::UpButton) == true)
			{
				pos.Y -= speed;
			}
			else if (IsButtonPush(ButtonKind::DownButton) == true) 
			{
				pos.Y += speed;
			}
			else if (IsButtonPush(ButtonKind::Button01))
			{
				pos = Vec2(200, 200);
			}
			else if (IsButtonPush(ButtonKind::Button02))
			{
				pos = Vec2(400, 300);
			}

			DrawStart();

			DrawTexture(pos.X, pos.Y, GetTexture(TextureList::Enemy));

			DrawEnd();
		}
	}

	// エンジン終了
	EndEngine();

	return 0;
}

