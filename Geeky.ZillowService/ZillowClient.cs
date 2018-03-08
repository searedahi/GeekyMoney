namespace Zillow.Services
{
    #region Namespaces

    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    using System.Web;
    using System.Xml.Serialization;
    using Zillow.Services.Schema;

    #endregion

    /// <summary>
    /// Client for accessing and creating zillow web service objects
    /// </summary>
    public partial class ZillowClient : IZillowClient
    {
        #region Private Members

        private string _zwsid = string.Empty;

        #endregion

        #region Public Members

        /// <summary>
        /// Zillow Web Service ID
        /// </summary>
        public string Zwsid
        {
            get
            {
                if (_zwsid == string.Empty)
                    throw new Exception("Zillow Web Service Identifier Not Set!");
                return _zwsid;
            }
            private set { _zwsid = value; }
        }

        #endregion

        #region Contructors

        /// <summary>
        /// Overloaded Contructor passing Zillow Web Service ID
        /// </summary>
        /// <param name="zwsid">Zillow Web Service ID</param>
        public ZillowClient(string zwsid)
        {

            if (string.IsNullOrEmpty(zwsid))
                throw new ArgumentException("Zillow ID API access key is required", "zwsid");

            Zwsid = zwsid;
        }

        #endregion

        #region Private Methods

        private object CallAPI(string uri, Hashtable parameters, Type t)
        {
            try
            {
                // Build HttpClient request
                using (var httpClient = new HttpClient())
                {
                    // Read XML and Deserialize Object
                    var u = new UriBuilder(uri);
                    var query = HttpUtility.ParseQueryString(string.Empty);

                    foreach (string k in parameters.Keys)
                        query[k] = parameters[k].ToString();

                    u.Query = query.ToString();
                    var xml = httpClient.GetStringAsync(u.Uri).Result;

                    XmlSerializer ser = new XmlSerializer(t);
                    return ser.Deserialize(new StringReader(xml));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, ex);
                throw ex;
            }

        }

        #endregion

        #region Public Sync Methods

        public searchresults GetSearchResults(string address, string citystatezip)
        {
            try
            {

                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"address", address},
                    {"citystatezip", citystatezip}
                };

                searchresults search = (searchresults)CallAPI(ZillowURI.SearchResults, p, typeof(searchresults));

                if (search == null)
                    throw new NullReferenceException("searchresults API value is null");

                if (int.Parse(search.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", search.message.code, search.message.text));

                return search;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public zestimateResultType GetZestimate(string zpid)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"zpid", zpid}
                };

                zestimateResultType zestimate = (zestimateResultType)CallAPI(ZillowURI.ZEstimate, p, typeof(zestimateResultType));

                if (zestimate == null)
                    throw new NullReferenceException("zestimateResultType API value is null");

                if (int.Parse(zestimate.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", zestimate.message.code, zestimate.message.text));

                return zestimate;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public chart GetChart(string zpid, string unittype, string width, string height)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"zpid", zpid},
                    {"unit-type", unittype},
                    {"width", width},
                    {"height", height}
                };

                chart c = (chart)CallAPI(ZillowURI.Chart, p, typeof(chart));

                if (c == null)
                    throw new NullReferenceException("chart API value is null");

                if (int.Parse(c.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", c.message.code, c.message.text));

                return c;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public comps GetComps(string zpid, string count)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"zpid", zpid},
                    {"count", count}
                };

                comps c = (comps)CallAPI(ZillowURI.Comps, p, typeof(comps));

                if (c == null)
                    throw new NullReferenceException("comps API value is null");

                if (int.Parse(c.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", c.message.code, c.message.text));

                return c;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public regionchart GetRegionChart(string city, string state, string neighborhood, string zip, string unittype, string width, string height, SimpleChartDuration chartDuration, ChartVariant chartVariant)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"city", city},
                    {"state", state},
                    {"neighborhood", neighborhood},
                    {"zip", zip},
                    {"unit-type", unittype},
                    {"width", width},
                    {"height", height},
                    {"chartDuration", ZillowExtensions.GetXmlName(chartDuration)},
                    {"chartVariant", chartVariant}
                };

                regionchart c = (regionchart)CallAPI(ZillowURI.RegionChart, p, typeof(regionchart));

                if (c == null)
                    throw new NullReferenceException("regionchart API value is null");

                if (int.Parse(c.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", c.message.code, c.message.text));

                return c;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public demographicsResultType GetDemographics(string rid, string state, string city, string neighborhood)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"rid", rid},
                    {"state", state},
                    {"city", city},
                    {"neighborhood", neighborhood}
                };

                demographicsResultType demo = (demographicsResultType)CallAPI(ZillowURI.DemoGraphics, p, typeof(demographicsResultType));

                if (demo == null)
                    throw new NullReferenceException("demographicsResultType API value is null");

                if (int.Parse(demo.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", demo.message.code, demo.message.text));

                return demo;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public regionchildrenResultType GetRegionChildren(string regionid, string country, string state, string county, string city, string childtype)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"regionid", regionid},
                    {"country", country},
                    {"state", state},
                    {"childtype", childtype}
                };

                regionchildrenResultType rc = (regionchildrenResultType)CallAPI(ZillowURI.RegionChildren, p, typeof(regionchildrenResultType));

                if (rc == null)
                    throw new NullReferenceException("regionchildrenResultType API value is null");

                if (int.Parse(rc.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", rc.message.code, rc.message.text));

                return rc;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public rateSummaryResultType GetRateSummary(string state, string output, string callback)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"state", state},
                    {"output", output},
                    {"callback", callback}
                };

                rateSummaryResultType rs = (rateSummaryResultType)CallAPI(ZillowURI.RateSummary, p, typeof(rateSummaryResultType));

                if (rs == null)
                    throw new NullReferenceException("rateSummaryResultType API value is null");

                if (int.Parse(rs.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", rs.message.code, rs.message.text));

                return rs;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public paymentsSummaryResultType GetMonthlyPayments(int price, int down, int dollarsdown, int zip, string output, string callback)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"price", price},
                    {"down", down},
                    {"dollarsdown", dollarsdown},
                    {"zip", zip},
                    {"output", output},
                    {"callback", callback}
                };

                paymentsSummaryResultType ps = (paymentsSummaryResultType)CallAPI(ZillowURI.RegionChildren, p, typeof(paymentsSummaryResultType));

                if (ps == null)
                    throw new NullReferenceException("paymentsSummaryResultType API value is null");

                if (int.Parse(ps.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", ps.message.code, ps.message.text));

                return ps;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public searchresults GetDeepSearchResults(string address, string citystatezip)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"address", address},
                    {"citystatezip", citystatezip}
                };

                searchresults search = (searchresults)CallAPI(ZillowURI.DeepSearchResults, p, typeof(searchresults));

                if (search == null)
                    throw new NullReferenceException("searchresults API value is null");

                if (int.Parse(search.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", search.message.code, search.message.text));

                return search;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public comps GetDeepComps(string zpid, string count)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"zpid", zpid},
                    {"count", count}
                };

                comps comps = (comps)CallAPI(ZillowURI.DeepComps, p, typeof(comps));

                if (comps == null)
                    throw new NullReferenceException("searchresults API value is null");

                if (int.Parse(comps.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", comps.message.code, comps.message.text));

                return comps;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        public updatedPropertyDetails GetUpdatedPropertyDetails(uint zpid)
        {
            try
            {
                Hashtable p = new Hashtable
                {
                    {"zws-id", Zwsid},
                    {"zpid", zpid}
                };

                updatedPropertyDetails upd = (updatedPropertyDetails)CallAPI(ZillowURI.UpdatedPropertyDetails, p, typeof(updatedPropertyDetails));

                if (upd == null)
                    throw new NullReferenceException("searchresults API value is null");

                if (int.Parse(upd.message.code) != 0)
                    throw new Exception(string.Format("Zillow Error #{0}: {1}", upd.message.code, upd.message.text));

                return upd;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }

        #endregion

    }
}
