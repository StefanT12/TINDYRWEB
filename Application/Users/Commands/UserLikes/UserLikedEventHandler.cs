using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Behaviours;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.UserLikes
{
    public class UserLikedEventHandler : INotificationHandler<UserLikedEvent>
    {
        private const string NotificationMessageTemplate = "<a href=\"{0}\">{1}</a> liked your <a href=\"{2}\">profile.</a>";

        //private readonly ISession _session;

        //public UserLikedEventHandler(ISession session)
        //{
        //    _session = session ?? throw new ArgumentNullException(nameof(session));
        //}

        //public async Task Handle(UserLikedEvent notification, CancellationToken cancellationToken)
        //{
        //    using (var tx = _session.BeginTransaction())
        //    {
        //        try
        //        {
        //            var postQuery = _session.QueryOver<User>()
        //                .Fetch(SelectMode.Fetch, p => p.Username)
        //                .Where(p => p.ID == notification.UserID)
        //                .FutureValue();

        //            var senderQuery = _session.QueryOver<User>()
        //                .Where(Restrictions.Eq("Username", notification.Username))
        //                .FutureValue();

        //            var post = await postQuery.GetValueAsync();
        //            var message = string.Format(NotificationMessageTemplate,
        //                notification.LikerProfileUrl,
        //                notification.LikerUsername );

        //            var notificationToInsert = new Notification(await senderQuery.GetValueAsync(), post.User, message);

        //            await _session.SaveAsync(notificationToInsert);
        //            await tx.CommitAsync();
        //        }
        //        catch (ADOException ex)
        //        {
        //            await tx.RollbackAsync();
        //            throw ex;
        //        }
        //    }
        

    }
}
