﻿using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods for the /user-blocks endpoints.
    /// </summary>
    public class UserBlocksClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="UserBlocksClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public UserBlocksClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Get a user's blocks by identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the user. Can be a user's email address, username or phone number.</param>
        /// <returns>The <see cref="UserBlocks"/> relating to the user requested.</returns>
        public Task<UserBlocks> GetByIdentifierAsync(string identifier)
        {
            return Connection.GetAsync<UserBlocks>("user-blocks",
                null,
                new Dictionary<string, string>
                {
                    {"identifier", identifier}
                }, null, null);
        }

        /// <summary>
        /// Get a user's blocks by user id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <returns>The <see cref="UserBlocks"/> relating to the user requested.</returns>
        public Task<UserBlocks> GetByUserIdAsync(string id)
        {
            return Connection.GetAsync<UserBlocks>("user-blocks/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                null, null, null);
        }

        /// <summary>
        /// Unblock a user by their identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the user to unblock. Can be a user's email address, username or phone number.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous unblock operation.</returns>
        public Task UnblockByIdentifierAsync(string identifier)
        {
            return Connection.DeleteAsync<object>("user-blocks",
                null,
                new Dictionary<string, string>
                {
                    {"identifier", identifier}
                });
        }

        /// <summary>
        /// Unblock a user by their id.
        /// </summary>
        /// <param name="id">The id of the user to unblock.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous unblock operation.</returns>
        public Task UnblockByUserIdAsync(string id)
        {
            return Connection.DeleteAsync<object>("user-blocks/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }
    }
}