
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgMain))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text E_PlayerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlayerNameText == null )
     			{
		    		this.m_E_PlayerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Top/PlayerRoot/E_PlayerName");
     			}
     			return this.m_E_PlayerNameText;
     		}
     	}

		public UnityEngine.UI.Joystick E_JoystickJoystick
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JoystickJoystick == null )
     			{
		    		this.m_E_JoystickJoystick = UIFindHelper.FindDeepChild<UnityEngine.UI.Joystick>(this.uiTransform.gameObject,"Bottom/Joy/E_Joystick");
     			}
     			return this.m_E_JoystickJoystick;
     		}
     	}

		public UnityEngine.UI.Image E_JoystickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_JoystickImage == null )
     			{
		    		this.m_E_JoystickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/Joy/E_Joystick");
     			}
     			return this.m_E_JoystickImage;
     		}
     	}

		public UnityEngine.UI.Button EBtnFunction1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnFunction1Button == null )
     			{
		    		this.m_EBtnFunction1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bottom/Menu/EBtnFunction1");
     			}
     			return this.m_EBtnFunction1Button;
     		}
     	}

		public UnityEngine.UI.Image EIconFunc1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EIconFunc1Image == null )
     			{
		    		this.m_EIconFunc1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/Menu/EBtnFunction1/EIconFunc1");
     			}
     			return this.m_EIconFunc1Image;
     		}
     	}

		public UnityEngine.UI.Text ETextFunc1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETextFunc1Text == null )
     			{
		    		this.m_ETextFunc1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bottom/Menu/EBtnFunction1/ETextFunc1");
     			}
     			return this.m_ETextFunc1Text;
     		}
     	}

		public UnityEngine.UI.Image EIMgCD1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EIMgCD1Image == null )
     			{
		    		this.m_EIMgCD1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/Menu/EBtnFunction1/EIMgCD1");
     			}
     			return this.m_EIMgCD1Image;
     		}
     	}

		public UnityEngine.UI.Image EImgMask1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImgMask1Image == null )
     			{
		    		this.m_EImgMask1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bottom/Menu/EBtnFunction1/EImgMask1");
     			}
     			return this.m_EImgMask1Image;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_PlayerNameText = null;
			this.m_E_JoystickJoystick = null;
			this.m_E_JoystickImage = null;
			this.m_EBtnFunction1Button = null;
			this.m_EIconFunc1Image = null;
			this.m_ETextFunc1Text = null;
			this.m_EIMgCD1Image = null;
			this.m_EImgMask1Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_PlayerNameText = null;
		private UnityEngine.UI.Joystick m_E_JoystickJoystick = null;
		private UnityEngine.UI.Image m_E_JoystickImage = null;
		private UnityEngine.UI.Button m_EBtnFunction1Button = null;
		private UnityEngine.UI.Image m_EIconFunc1Image = null;
		private UnityEngine.UI.Text m_ETextFunc1Text = null;
		private UnityEngine.UI.Image m_EIMgCD1Image = null;
		private UnityEngine.UI.Image m_EImgMask1Image = null;
		public Transform uiTransform = null;
	}
}
