package mono.com.baidu.mapapi.search.poi;


public class OnGetPoiSearchResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.poi.OnGetPoiSearchResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetPoiDetailResult:(Lcom/baidu/mapapi/search/poi/PoiDetailResult;)V:GetOnGetPoiDetailResult_Lcom_baidu_mapapi_search_poi_PoiDetailResult_Handler:Com.Baidu.Mapapi.Search.Poi.IOnGetPoiSearchResultListenerInvoker, BDmap\n" +
			"n_onGetPoiIndoorResult:(Lcom/baidu/mapapi/search/poi/PoiIndoorResult;)V:GetOnGetPoiIndoorResult_Lcom_baidu_mapapi_search_poi_PoiIndoorResult_Handler:Com.Baidu.Mapapi.Search.Poi.IOnGetPoiSearchResultListenerInvoker, BDmap\n" +
			"n_onGetPoiResult:(Lcom/baidu/mapapi/search/poi/PoiResult;)V:GetOnGetPoiResult_Lcom_baidu_mapapi_search_poi_PoiResult_Handler:Com.Baidu.Mapapi.Search.Poi.IOnGetPoiSearchResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.Poi.IOnGetPoiSearchResultListenerImplementor, BDmap", OnGetPoiSearchResultListenerImplementor.class, __md_methods);
	}


	public OnGetPoiSearchResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetPoiSearchResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.Poi.IOnGetPoiSearchResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetPoiDetailResult (com.baidu.mapapi.search.poi.PoiDetailResult p0)
	{
		n_onGetPoiDetailResult (p0);
	}

	private native void n_onGetPoiDetailResult (com.baidu.mapapi.search.poi.PoiDetailResult p0);


	public void onGetPoiIndoorResult (com.baidu.mapapi.search.poi.PoiIndoorResult p0)
	{
		n_onGetPoiIndoorResult (p0);
	}

	private native void n_onGetPoiIndoorResult (com.baidu.mapapi.search.poi.PoiIndoorResult p0);


	public void onGetPoiResult (com.baidu.mapapi.search.poi.PoiResult p0)
	{
		n_onGetPoiResult (p0);
	}

	private native void n_onGetPoiResult (com.baidu.mapapi.search.poi.PoiResult p0);

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
