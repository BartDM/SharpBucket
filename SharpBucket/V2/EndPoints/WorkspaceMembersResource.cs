﻿using System.Collections.Generic;
using System.Threading;
using SharpBucket.V2.Pocos;

namespace SharpBucket.V2.EndPoints
{
    public class WorkspaceMembersResource : EndPoint
    {
        internal WorkspaceMembersResource(WorkspaceResource workspaceResource)
            : base(workspaceResource, "members/")
        {
        }

        /// <summary>
        /// Gets the members of the workspace.
        /// </summary>
        /// <param name="max">The maximum number of items to return. 0 returns all items.</param>
        public List<WorkspaceMembership> ListMembers(int max = 0)
        {
            return _sharpBucketV2.GetPaginatedValues<WorkspaceMembership>(_baseUrl, max);
        }

        /// <summary>
        /// Enumerate the members of the workspace,
        /// doing requests page by page while enumerating.
        /// </summary>
        /// <param name="pageLen">
        /// The length of a page. If not defined the default page length will be used
        /// </param>
        public IEnumerable<WorkspaceMembership> EnumerateMembers(int? pageLen = null)
        {
            return _sharpBucketV2.EnumeratePaginatedValues<WorkspaceMembership>(_baseUrl, pageLen: pageLen);
        }

#if CS_8
        /// <summary>
        /// Enumerate the members of the workspace,
        /// doing requests page by page while enumerating.
        /// </summary>
        /// <param name="token">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        public IAsyncEnumerable<WorkspaceMembership> EnumerateMembersAsync(CancellationToken token = default)
            => EnumerateMembersAsync(null, token);

        /// <summary>
        /// Enumerate the members of the workspace,
        /// doing requests page by page while enumerating.
        /// </summary>
        /// <param name="pageLen">
        /// The length of a page. If not defined the default page length will be used
        /// </param>
        /// <param name="token">
        /// A cancellation token that can be used by other objects or threads to receive notice of cancellation.
        /// </param>
        public IAsyncEnumerable<WorkspaceMembership> EnumerateMembersAsync(int? pageLen, CancellationToken token = default)
        {
            return _sharpBucketV2.EnumeratePaginatedValuesAsync<WorkspaceMembership>(_baseUrl, null, pageLen, token);
        }
#endif
    }
}
