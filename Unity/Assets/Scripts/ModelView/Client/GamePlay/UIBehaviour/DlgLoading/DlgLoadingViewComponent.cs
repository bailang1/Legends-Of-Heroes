
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgLoading))]
	[EnableMethod]
	public  class DlgLoadingViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image E_ImgLoadingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ImgLoadingImage == null )
     			{
		    		this.m_E_ImgLoadingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"LoadingBg/E_ImgLoading");
     			}
     			return this.m_E_ImgLoadingImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ImgLoadingImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_ImgLoadingImage = null;
		public Transform uiTransform = null;
	}
}
