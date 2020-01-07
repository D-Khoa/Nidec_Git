using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrackingPQMData.Controller
{
    public class CancellableExecutor
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = CancellationToken.None;

        public CancellableExecutor()
        {
            token = cts.Token;
        }

        public Task Execute(Action<CancellationToken> action)
        {
            return Task.Run(() => action(token), token);
        }

        public void Cancel()
        {
            cts.Cancel();
            cts.Dispose();
            cts = new CancellationTokenSource();
            token = cts.Token;
        }
    }
}
