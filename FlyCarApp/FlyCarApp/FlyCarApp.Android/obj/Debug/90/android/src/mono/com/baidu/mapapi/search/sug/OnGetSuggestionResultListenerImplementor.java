package mono.com.baidu.mapapi.search.sug;


public class OnGetSuggestionResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.sug.OnGetSuggestionResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetSuggestionResult:(Lcom/baidu/mapapi/search/sug/SuggestionResult;)V:GetOnGetSuggestionResult_Lcom_baidu_mapapi_search_sug_SuggestionResult_Handler:Com.Baidu.Mapapi.Search.Sug.IOnGetSuggestionResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.Sug.IOnGetSuggestionResultListenerImplementor, BDmap", OnGetSuggestionResultListenerImplementor.class, __md_methods);
	}


	public OnGetSuggestionResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetSuggestionResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.Sug.IOnGetSuggestionResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetSuggestionResult (com.baidu.mapapi.search.sug.SuggestionResult p0)
	{
		n_onGetSuggestionResult (p0);
	}

	private native void n_onGetSuggestionResult (com.baidu.mapapi.search.sug.SuggestionResult p0);

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
