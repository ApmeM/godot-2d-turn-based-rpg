using System;
using System.Threading;
using System.Threading.Tasks;

namespace TurnBase
{
    public static class TaskExtensions
    {
        public static async Task WrapCancellation(this Task signalTask, CancellationToken cancellationToken, bool isFail = true)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                await signalTask;
                return;
            }

            var cancelTask = Task.Delay(Timeout.Infinite, cancellationToken);

            var completed = await Task.WhenAny(signalTask, cancelTask);

            if (completed == cancelTask)
            {
                if(isFail)
                {
                    throw new OperationCanceledException(cancellationToken);
                }
                else
                {
                    return;
                }
                throw new OperationCanceledException(cancellationToken);
            }

            await signalTask;
        }

        public static async Task<T> WrapCancellation<T>(this Task<T> signalTask, CancellationToken cancellationToken, bool isFail = true)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return await signalTask;
            }

            var cancelTask = Task.Delay(Timeout.Infinite, cancellationToken);

            var completed = await Task.WhenAny(signalTask, cancelTask);

            if (completed == cancelTask)
            {
                if(isFail)
                {
                    throw new OperationCanceledException(cancellationToken);
                }
                else
                {
                    return default(T);
                }
            }

            return await signalTask;
        }
    }
}
