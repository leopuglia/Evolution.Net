using System;

namespace EvolutionNet.MVP.UI.Windows.SingleInstance
{
    /// <summary>
    /// Provides a proxy to communicate with the first instance of the application.
    /// </summary>
    internal class SingleInstanceProxy : MarshalByRefObject
    {
        #region Member Variables

        private ISingleInstanceEnforcer enforcer;

        #endregion

        #region Construction / Destruction

        /// <summary>
        /// Instantiates a new SingleInstanceProxy object.
        /// </summary>
        /// <param name="enforcer">The enforcer (first instance of the application) which will receive messages from the new instances of the application.</param>
        /// <exception cref="System.ArgumentNullException">enforcer is null.</exception>
        public SingleInstanceProxy(ISingleInstanceEnforcer enforcer)
        {
            if (enforcer == null)
                throw new ArgumentNullException("enforcer", "enforcer cannot be null.");

            this.enforcer = enforcer;
        }

        #endregion

        #region Overriden MarshalByRefObject Members

        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>An object of type System.Runtime.Remoting.Lifetime.ILease used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime property.</returns>
        /// <exception cref="System.Security.SecurityException">The immediate caller does not have infrastructure permission.</exception>
        public override object InitializeLifetimeService()
        {
            return null;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the enforcer (first instance of the application) which will receive messages from the new instances of the application.
        /// </summary>
        public ISingleInstanceEnforcer Enforcer
        {
            get
            {
                return enforcer;
            }
        }

        #endregion
    }
}