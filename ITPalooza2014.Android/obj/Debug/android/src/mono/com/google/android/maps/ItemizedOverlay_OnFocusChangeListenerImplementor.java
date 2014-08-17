package mono.com.google.android.maps;


public class ItemizedOverlay_OnFocusChangeListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.maps.ItemizedOverlay.OnFocusChangeListener
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onFocusChanged:(Lcom/google/android/maps/ItemizedOverlay;Lcom/google/android/maps/OverlayItem;)V:GetOnFocusChanged_Lcom_google_android_maps_ItemizedOverlay_Lcom_google_android_maps_OverlayItem_Handler:Android.GoogleMaps.ItemizedOverlay/IOnFocusChangeListenerInvoker, Mono.Android.GoogleMaps\n" +
			"";
		mono.android.Runtime.register ("Android.GoogleMaps.ItemizedOverlay/IOnFocusChangeListenerImplementor, Mono.Android.GoogleMaps, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", ItemizedOverlay_OnFocusChangeListenerImplementor.class, __md_methods);
	}


	public ItemizedOverlay_OnFocusChangeListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ItemizedOverlay_OnFocusChangeListenerImplementor.class)
			mono.android.TypeManager.Activate ("Android.GoogleMaps.ItemizedOverlay/IOnFocusChangeListenerImplementor, Mono.Android.GoogleMaps, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", "", this, new java.lang.Object[] {  });
	}


	public void onFocusChanged (com.google.android.maps.ItemizedOverlay p0, com.google.android.maps.OverlayItem p1)
	{
		n_onFocusChanged (p0, p1);
	}

	private native void n_onFocusChanged (com.google.android.maps.ItemizedOverlay p0, com.google.android.maps.OverlayItem p1);

	java.util.ArrayList refList;
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
