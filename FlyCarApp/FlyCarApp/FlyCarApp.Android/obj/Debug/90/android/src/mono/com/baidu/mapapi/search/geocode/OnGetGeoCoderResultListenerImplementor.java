package mono.com.baidu.mapapi.search.geocode;


public class OnGetGeoCoderResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.geocode.OnGetGeoCoderResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetGeoCodeResult:(Lcom/baidu/mapapi/search/geocode/GeoCodeResult;)V:GetOnGetGeoCodeResult_Lcom_baidu_mapapi_search_geocode_GeoCodeResult_Handler:Com.Baidu.Mapapi.Search.Geocode.IOnGetGeoCoderResultListenerInvoker, BDmap\n" +
			"n_onGetReverseGeoCodeResult:(Lcom/baidu/mapapi/search/geocode/ReverseGeoCodeResult;)V:GetOnGetReverseGeoCodeResult_Lcom_baidu_mapapi_search_geocode_ReverseGeoCodeResult_Handler:Com.Baidu.Mapapi.Search.Geocode.IOnGetGeoCoderResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.Geocode.IOnGetGeoCoderResultListenerImplementor, BDmap", OnGetGeoCoderResultListenerImplementor.class, __md_methods);
	}


	public OnGetGeoCoderResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetGeoCoderResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.Geocode.IOnGetGeoCoderResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetGeoCodeResult (com.baidu.mapapi.search.geocode.GeoCodeResult p0)
	{
		n_onGetGeoCodeResult (p0);
	}

	private native void n_onGetGeoCodeResult (com.baidu.mapapi.search.geocode.GeoCodeResult p0);


	public void onGetReverseGeoCodeResult (com.baidu.mapapi.search.geocode.ReverseGeoCodeResult p0)
	{
		n_onGetReverseGeoCodeResult (p0);
	}

	private native void n_onGetReverseGeoCodeResult (com.baidu.mapapi.search.geocode.ReverseGeoCodeResult p0);

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
