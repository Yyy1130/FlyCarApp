package mono.com.baidu.mapapi.map;


public class BaiduMap_OnMapStatusChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.baidu.mapapi.map.BaiduMap.OnMapStatusChangeListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMapStatusChange:(Lcom/baidu/mapapi/map/MapStatus;)V:GetOnMapStatusChange_Lcom_baidu_mapapi_map_MapStatus_Handler:Com.Baidu.Mapapi.Map.BaiduMap/IOnMapStatusChangeListenerInvoker, BDmap\n" +
			"n_onMapStatusChangeFinish:(Lcom/baidu/mapapi/map/MapStatus;)V:GetOnMapStatusChangeFinish_Lcom_baidu_mapapi_map_MapStatus_Handler:Com.Baidu.Mapapi.Map.BaiduMap/IOnMapStatusChangeListenerInvoker, BDmap\n" +
			"n_onMapStatusChangeStart:(Lcom/baidu/mapapi/map/MapStatus;)V:GetOnMapStatusChangeStart_Lcom_baidu_mapapi_map_MapStatus_Handler:Com.Baidu.Mapapi.Map.BaiduMap/IOnMapStatusChangeListenerInvoker, BDmap\n" +
			"n_onMapStatusChangeStart:(Lcom/baidu/mapapi/map/MapStatus;I)V:GetOnMapStatusChangeStart2_Lcom_baidu_mapapi_map_MapStatus_IHandler:Com.Baidu.Mapapi.Map.BaiduMap/IOnMapStatusChangeListenerInvoker, BDmap\n" +
			"";
		mono.android.Runtime.register ("Com.Baidu.Mapapi.Map.BaiduMap+IOnMapStatusChangeListenerImplementor, BDmap", BaiduMap_OnMapStatusChangeListenerImplementor.class, __md_methods);
	}


	public BaiduMap_OnMapStatusChangeListenerImplementor ()
	{
		super ();
		if (getClass () == BaiduMap_OnMapStatusChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Baidu.Mapapi.Map.BaiduMap+IOnMapStatusChangeListenerImplementor, BDmap", "", this, new java.lang.Object[] {  });
	}


	public void onMapStatusChange (com.baidu.mapapi.map.MapStatus p0)
	{
		n_onMapStatusChange (p0);
	}

	private native void n_onMapStatusChange (com.baidu.mapapi.map.MapStatus p0);


	public void onMapStatusChangeFinish (com.baidu.mapapi.map.MapStatus p0)
	{
		n_onMapStatusChangeFinish (p0);
	}

	private native void n_onMapStatusChangeFinish (com.baidu.mapapi.map.MapStatus p0);


	public void onMapStatusChangeStart (com.baidu.mapapi.map.MapStatus p0)
	{
		n_onMapStatusChangeStart (p0);
	}

	private native void n_onMapStatusChangeStart (com.baidu.mapapi.map.MapStatus p0);


	public void onMapStatusChangeStart (com.baidu.mapapi.map.MapStatus p0, int p1)
	{
		n_onMapStatusChangeStart (p0, p1);
	}

	private native void n_onMapStatusChangeStart (com.baidu.mapapi.map.MapStatus p0, int p1);

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
