package mono.com.baidu.mapapi.search.share;


public class OnGetShareUrlResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.share.OnGetShareUrlResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetLocationShareUrlResult:(Lcom/baidu/mapapi/search/share/ShareUrlResult;)V:GetOnGetLocationShareUrlResult_Lcom_baidu_mapapi_search_share_ShareUrlResult_Handler:Com.Baidu.Mapapi.Search.Share.IOnGetShareUrlResultListenerInvoker, BDmap\n" +
			"n_onGetPoiDetailShareUrlResult:(Lcom/baidu/mapapi/search/share/ShareUrlResult;)V:GetOnGetPoiDetailShareUrlResult_Lcom_baidu_mapapi_search_share_ShareUrlResult_Handler:Com.Baidu.Mapapi.Search.Share.IOnGetShareUrlResultListenerInvoker, BDmap\n" +
			"n_onGetRouteShareUrlResult:(Lcom/baidu/mapapi/search/share/ShareUrlResult;)V:GetOnGetRouteShareUrlResult_Lcom_baidu_mapapi_search_share_ShareUrlResult_Handler:Com.Baidu.Mapapi.Search.Share.IOnGetShareUrlResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.Share.IOnGetShareUrlResultListenerImplementor, BDmap", OnGetShareUrlResultListenerImplementor.class, __md_methods);
	}


	public OnGetShareUrlResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetShareUrlResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.Share.IOnGetShareUrlResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetLocationShareUrlResult (com.baidu.mapapi.search.share.ShareUrlResult p0)
	{
		n_onGetLocationShareUrlResult (p0);
	}

	private native void n_onGetLocationShareUrlResult (com.baidu.mapapi.search.share.ShareUrlResult p0);


	public void onGetPoiDetailShareUrlResult (com.baidu.mapapi.search.share.ShareUrlResult p0)
	{
		n_onGetPoiDetailShareUrlResult (p0);
	}

	private native void n_onGetPoiDetailShareUrlResult (com.baidu.mapapi.search.share.ShareUrlResult p0);


	public void onGetRouteShareUrlResult (com.baidu.mapapi.search.share.ShareUrlResult p0)
	{
		n_onGetRouteShareUrlResult (p0);
	}

	private native void n_onGetRouteShareUrlResult (com.baidu.mapapi.search.share.ShareUrlResult p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
