package mono.com.baidu.mapapi.search.busline;


public class OnGetBusLineSearchResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.busline.OnGetBusLineSearchResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetBusLineResult:(Lcom/baidu/mapapi/search/busline/BusLineResult;)V:GetOnGetBusLineResult_Lcom_baidu_mapapi_search_busline_BusLineResult_Handler:Com.Baidu.Mapapi.Search.Busline.IOnGetBusLineSearchResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.Busline.IOnGetBusLineSearchResultListenerImplementor, BDmap", OnGetBusLineSearchResultListenerImplementor.class, __md_methods);
	}


	public OnGetBusLineSearchResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetBusLineSearchResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.Busline.IOnGetBusLineSearchResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetBusLineResult (com.baidu.mapapi.search.busline.BusLineResult p0)
	{
		n_onGetBusLineResult (p0);
	}

	private native void n_onGetBusLineResult (com.baidu.mapapi.search.busline.BusLineResult p0);

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
