package md5ce8cc6688a0e16b01fbd5c2909330356;


public class SplashScreenView
	extends mvvmcross.droid.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Redoubt.UI.Droid.Views.SplashScreenView, Redoubt.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SplashScreenView.class, __md_methods);
	}


	public SplashScreenView ()
	{
		super ();
		if (getClass () == SplashScreenView.class)
			mono.android.TypeManager.Activate ("Redoubt.UI.Droid.Views.SplashScreenView, Redoubt.UI.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
