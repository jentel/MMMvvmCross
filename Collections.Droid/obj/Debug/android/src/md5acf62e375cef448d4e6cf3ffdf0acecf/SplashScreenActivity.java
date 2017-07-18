package md5acf62e375cef448d4e6cf3ffdf0acecf;


public class SplashScreenActivity
	extends mvvmcross.droid.views.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Collections.Droid.SplashScreenActivity, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SplashScreenActivity.class, __md_methods);
	}


	public SplashScreenActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SplashScreenActivity.class)
			mono.android.TypeManager.Activate ("Collections.Droid.SplashScreenActivity, Collections.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
