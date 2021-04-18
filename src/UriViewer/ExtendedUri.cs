using System;
using System.Collections.Specialized;
using System.Web;

namespace UriViewer
{
	public sealed class ExtendedUri : Uri
	{
		private NameValueCollection queryString = new NameValueCollection();

		public ExtendedUri(string uriString, UriKind kind) 
			: base(uriString, kind) 
		{
			this.CreateQueryStringTable();
		}

		public ExtendedUri(string uriString)
			: base(uriString)
		{
			this.CreateQueryStringTable();
		}

		public ExtendedUri(Uri baseUri, string relativeUri)
			: base(baseUri, relativeUri)
		{
			this.CreateQueryStringTable();
		}

		private void CreateQueryStringTable()
		{
			string query = string.Empty;

			if (this.IsAbsoluteUri)
			{
				if (!string.IsNullOrEmpty(this.Query))
				{
					query = this.Query;
				}
			}
			else
			{
				string[] uriParts = this.OriginalString.Split('?');
				query = uriParts[uriParts.Length - 1];
			}

			//  Removes the "?" in front.
			if (query.StartsWith("?") == true)
			{
				query = query.Substring(1);
			}

			this.queryString = HttpUtility.ParseQueryString(query);
		}

		/*
		NOTE: The Cursor property has an image + value in the drop down list.
		The Anchor shows a custom UI in the drop down.
		ForeColor shows a tab view with 3 tabs in the drop down list
		Font shows a custom dialog.
        
		So...we need to pick...something.
		 */

		public NameValueCollection QueryString
		{
			get
			{
				return this.queryString;
			}
		}
	}
}
