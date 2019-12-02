﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SharpBucket.Utility;
using SharpBucket.V2.Pocos;

namespace SharpBucket.V2.EndPoints
{
    /// <summary>
    /// Manage pull requests for a repository. Use this resource to perform CRUD (create/read/update/delete) operations on a pull request. 
    /// More info:
    /// https://confluence.atlassian.com/display/BITBUCKET/pullrequests+Resource
    /// </summary>
    public class PullRequestsResource
    {
        private readonly RepositoriesEndPoint _repositoriesEndPoint;
        private readonly string _slug;
        private readonly string _accountName;

        #region Pull Requests Resource

        public PullRequestsResource(string accountName, string repoSlugOrName, RepositoriesEndPoint repositoriesEndPoint)
        {
            _accountName = accountName.GuidOrValue();
            _slug = repoSlugOrName.ToSlug();
            _repositoriesEndPoint = repositoriesEndPoint;
        }

        /// <summary>
        /// List all of a repository's open pull requests.
        /// </summary>
        /// <returns></returns>
        public List<PullRequest> ListPullRequests() => ListPullRequests(new ListParameters());

        /// <summary>
        /// List all of a repository's open pull requests.
        /// </summary>
        /// <param name="parameters">Parameters for the query.</param>
        /// <returns></returns>
        public List<PullRequest> ListPullRequests(ListParameters parameters)
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));
            return _repositoriesEndPoint.ListPullRequests(_accountName, _slug, parameters);
        }

        /// <summary>
        /// Creates a new pull request. The request URL you provide is the destination repository URL. 
        /// For this reason, you must specify an explicit source repository in the request object if you want to pull from a different repository.
        /// </summary>
        /// <param name="pullRequest">The pull request.</param>
        /// <returns></returns>
        public PullRequest PostPullRequest(PullRequest pullRequest)
        {
            return _repositoriesEndPoint.PostPullRequest(_accountName, _slug, pullRequest);
        }

        /// <summary>
        /// Creates a new pull request. The request URL you provide is the destination repository URL. 
        /// For this reason, you must specify an explicit source repository in the request object if you want to pull from a different repository.
        /// </summary>
        /// <param name="pullRequest">The pull request.</param>
        /// <param name="token">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<PullRequest> PostPullRequestAsync(PullRequest pullRequest, CancellationToken token = default)
        {
            return await _repositoriesEndPoint.PostPullRequestAsync(_accountName, _slug, pullRequest, token);
        }

        /// <summary>
        /// Updates an existing pull request. The pull request's status must be open. 
        /// With the exception of the source and destination parameters, the request body must include all the existing request parameters; 
        /// Omitting a parameter causes the server to drop the existing value. For example, if the pull requests already has 3 reviewers, 
        /// the request body must include these 3 reviewers to prevent Bitbucket from dropping them.
        /// </summary>
        /// <param name="pullRequest">The pull request.</param>
        /// <returns></returns>
        public PullRequest PutPullRequest(PullRequest pullRequest)
        {
            return _repositoriesEndPoint.PutPullRequest(_accountName, _slug, pullRequest);
        }

        /// <summary>
        /// Updates an existing pull request. The pull request's status must be open. 
        /// With the exception of the source and destination parameters, the request body must include all the existing request parameters; 
        /// Omitting a parameter causes the server to drop the existing value. For example, if the pull requests already has 3 reviewers, 
        /// the request body must include these 3 reviewers to prevent Bitbucket from dropping them.
        /// </summary>
        /// <param name="pullRequest">The pull request.</param>
        /// <param name="token">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        public async Task<PullRequest> PutPullRequestAsync(PullRequest pullRequest, CancellationToken token = default)
        {
            return await _repositoriesEndPoint.PutPullRequestAsync(_accountName, _slug, pullRequest, token);
        }

        /// <summary>
        /// Returns all the pull request activity for a repository. This call returns a historical log of all the pull request activity within a repository.
        /// </summary>
        /// <returns></returns>
        public List<Activity> GetPullRequestLog()
        {
            return _repositoriesEndPoint.GetPullRequestLog(_accountName, _slug);
        }

        #endregion

        #region Pull request Resource

        /// <summary>
        /// Get the Pull Request Resource.
        /// BitBucket does not have this Resource so this is a "Virtual" resource
        /// which offers easier manipulation of a specific Pull Request.
        /// </summary>
        /// <param name="pullRequestId">The pull request identifier.</param>
        /// <returns></returns>
        public PullRequestResource PullRequestResource(int pullRequestId)
        {
            return new PullRequestResource(_accountName, _slug, pullRequestId, _repositoriesEndPoint);
        }

        internal PullRequest GetPullRequest(int pullRequestId)
        {
            return _repositoriesEndPoint.GetPullRequest(_accountName, _slug, pullRequestId);
        }

        internal async Task<PullRequest> GetPullRequestAsync(int pullRequestId, CancellationToken token)
        {
            return await _repositoriesEndPoint.GetPullRequestAsync(_accountName, _slug, pullRequestId, token: token);
        }

        internal List<Commit> ListPullRequestCommits(int pullRequestId)
        {
            return _repositoriesEndPoint.ListPullRequestCommits(_accountName, _slug, pullRequestId);
        }

        internal PullRequestInfo ApprovePullRequest(int pullRequestId)
        {
            return _repositoriesEndPoint.ApprovePullRequest(_accountName, _slug, pullRequestId);
        }

        internal async Task<PullRequestInfo> ApprovePullRequestAsync(int pullRequestId, CancellationToken token)
        {
            return await _repositoriesEndPoint.ApprovePullRequestAsync(_accountName, _slug, pullRequestId, token: token);
        }

        internal void RemovePullRequestApproval(int pullRequestId)
        {
            _repositoriesEndPoint.RemovePullRequestApproval(_accountName, _slug, pullRequestId);
        }

        internal async Task RemovePullRequestApprovalAsync(int pullRequestId, CancellationToken token)
        {
            await _repositoriesEndPoint.RemovePullRequestApprovalAsync(_accountName, _slug, pullRequestId, token: token);
        }

        internal object GetDiffForPullRequest(int pullRequestId)
        {
            return _repositoriesEndPoint.GetDiffForPullRequest(_accountName, _slug, pullRequestId);
        }

        internal async Task<object> GetDiffForPullRequestAsync(int pullRequestId, CancellationToken token)
        {
            return await _repositoriesEndPoint.GetDiffForPullRequestAsync(_accountName, _slug, pullRequestId, token: token);
        }

        internal List<Activity> GetPullRequestActivity(int pullRequestId)
        {
            return _repositoriesEndPoint.GetPullRequestActivity(_accountName, _slug, pullRequestId);
        }

        internal Merge AcceptAndMergePullRequest(int pullRequestId)
        {
            return _repositoriesEndPoint.AcceptAndMergePullRequest(_accountName, _slug, pullRequestId);
        }

        internal async Task<Merge> AcceptAndMergePullRequestAsync(int pullRequestId, CancellationToken token)
        {
            return await _repositoriesEndPoint.AcceptAndMergePullRequestAsync(_accountName, _slug, pullRequestId, token: token);
        }

        internal PullRequest DeclinePullRequest(int pullRequestId)
        {
            return _repositoriesEndPoint.DeclinePullRequest(_accountName, _slug, pullRequestId);
        }

        internal async Task<PullRequest> DeclinePullRequestAsync(int pullRequestId, CancellationToken token)
        {
            return await _repositoriesEndPoint.DeclinePullRequestAsync(_accountName, _slug, pullRequestId, token: token);
        }

        internal List<Comment> ListPullRequestComments(int pullRequestId)
        {
            return _repositoriesEndPoint.ListPullRequestComments(_accountName, _slug, pullRequestId);
        }

        internal Comment GetPullRequestComment(int pullRequestId, int commentId)
        {
            return _repositoriesEndPoint.GetPullRequestComment(_accountName, _slug, pullRequestId, commentId);
        }

        internal async Task<Comment> GetPullRequestCommentAsync(int pullRequestId, int commentId, CancellationToken token)
        {
            return await _repositoriesEndPoint.GetPullRequestCommentAsync(_accountName, _slug, pullRequestId, commentId, token: token);
        }

        internal Comment PostPullRequestComment(int pullRequestId, Comment comment)
        {
            return _repositoriesEndPoint.PostPullRequestComment(_accountName, _slug, pullRequestId, comment);
        }

        internal async Task<Comment> PostPullRequestCommentAsync(int pullRequestId, Comment comment, CancellationToken token)
        {
            return await _repositoriesEndPoint.PostPullRequestCommentAsync(_accountName, _slug, pullRequestId, comment, token: token);
        }

        #endregion
    }
}
