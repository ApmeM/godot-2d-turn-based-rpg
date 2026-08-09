using System;
using System.Threading;
using System.Threading.Tasks;

namespace TurnBase
{
    public static class TaskExtensions
    {
        public static async Task WrapCancellation(this Task signalTask, CancellationToken cancellationToken)
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
                throw new OperationCanceledException(cancellationToken);
            }

            await signalTask;
        }

        public static async Task<T> WrapCancellation<T>(this Task<T> signalTask, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return await signalTask;
            }

            var cancelTask = Task.Delay(Timeout.Infinite, cancellationToken);

            var completed = await Task.WhenAny(signalTask, cancelTask);

            if (completed == cancelTask)
            {
                throw new OperationCanceledException(cancellationToken);
            }

            return await signalTask;
        }
    }
}
