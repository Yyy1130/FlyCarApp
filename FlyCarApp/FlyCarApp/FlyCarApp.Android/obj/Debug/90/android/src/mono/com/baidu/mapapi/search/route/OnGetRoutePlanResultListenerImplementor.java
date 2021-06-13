package mono.com.baidu.mapapi.search.route;


public class OnGetRoutePlanResultListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.search.route.OnGetRoutePlanResultListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onGetBikingRouteResult:(Lcom/baidu/mapapi/search/route/BikingRouteResult;)V:GetOnGetBikingRouteResult_Lcom_baidu_mapapi_search_route_BikingRouteResult_Handler:Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerInvoker, BDmap\n" +
			"n_onGetDrivingRouteResult:(Lcom/baidu/mapapi/search/route/DrivingRouteResult;)V:GetOnGetDrivingRouteResult_Lcom_baidu_mapapi_search_route_DrivingRouteResult_Handler:Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerInvoker, BDmap\n" +
			"n_onGetIndoorRouteResult:(Lcom/baidu/mapapi/search/route/IndoorRouteResult;)V:GetOnGetIndoorRouteResult_Lcom_baidu_mapapi_search_route_IndoorRouteResult_Handler:Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerInvoker, BDmap\n" +
			"n_onGetMassTransitRouteResult:(Lcom/baidu/mapapi/search/route/MassTransitRouteResult;)V:GetOnGetMassTransitRouteResult_Lcom_baidu_mapapi_search_route_MassTransitRouteResult_Handler:Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerInvoker, BDmap\n" +
			"n_onGetTransitRouteResult:(Lcom/baidu/mapapi/search/route/TransitRouteResult;)V:GetOnGetTransitRouteResult_Lcom_baidu_mapapi_search_route_TransitRouteResult_Handler:Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerInvoker, BDmap\n" +
			"n_onGetWalkingRouteResult:(Lcom/baidu/mapapi/search/route/WalkingRouteResult;)V:GetOnGetWalkingRouteResult_Lcom_baidu_mapapi_search_route_WalkingRouteResult_Handler:Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerImplementor, BDmap", OnGetRoutePlanResultListenerImplementor.class, __md_methods);
	}


	public OnGetRoutePlanResultListenerImplementor ()
	{
		super ();
		if (getClass () == OnGetRoutePlanResultListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Search.Route.IOnGetRoutePlanResultListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onGetBikingRouteResult (com.baidu.mapapi.search.route.BikingRouteResult p0)
	{
		n_onGetBikingRouteResult (p0);
	}

	private native void n_onGetBikingRouteResult (com.baidu.mapapi.search.route.BikingRouteResult p0);


	public void onGetDrivingRouteResult (com.baidu.mapapi.search.route.DrivingRouteResult p0)
	{
		n_onGetDrivingRouteResult (p0);
	}

	private native void n_onGetDrivingRouteResult (com.baidu.mapapi.search.route.DrivingRouteResult p0);


	public void onGetIndoorRouteResult (com.baidu.mapapi.search.route.IndoorRouteResult p0)
	{
		n_onGetIndoorRouteResult (p0);
	}

	private native void n_onGetIndoorRouteResult (com.baidu.mapapi.search.route.IndoorRouteResult p0);


	public void onGetMassTransitRouteResult (com.baidu.mapapi.search.route.MassTransitRouteResult p0)
	{
		n_onGetMassTransitRouteResult (p0);
	}

	private native void n_onGetMassTransitRouteResult (com.baidu.mapapi.search.route.MassTransitRouteResult p0);


	public void onGetTransitRouteResult (com.baidu.mapapi.search.route.TransitRouteResult p0)
	{
		n_onGetTransitRouteResult (p0);
	}

	private native void n_onGetTransitRouteResult (com.baidu.mapapi.search.route.TransitRouteResult p0);


	public void onGetWalkingRouteResult (com.baidu.mapapi.search.route.WalkingRouteResult p0)
	{
		n_onGetWalkingRouteResult (p0);
	}

	private native void n_onGetWalkingRouteResult (com.baidu.mapapi.search.route.WalkingRouteResult p0);

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
