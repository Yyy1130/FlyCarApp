package mono.com.baidu.mapapi.search.district;


public class OnGetDistricSearchResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.district.OnGetDistricSearchResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetDistrictResult:(Lcom/baidu/mapapi/search/district/DistrictResult;)V:GetOnGetDistrictResult_Lcom_baidu_mapapi_search_district_DistrictResult_Handler:Com.Baidu.Mapapi.Search.District.IOnGetDistricSearchResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.District.IOnGetDistricSearchResultListenerImplementor, BDmap", OnGetDistricSearchResultListenerImplementor.class, __md_methods);
	}


	public OnGetDistricSearchResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetDistricSearchResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.District.IOnGetDistricSearchResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetDistrictResult (com.baidu.mapapi.search.district.DistrictResult p0)
	{
		n_onGetDistrictResult (p0);
	}

	private native void n_onGetDistrictResult (com.baidu.mapapi.search.district.DistrictResult p0);

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
