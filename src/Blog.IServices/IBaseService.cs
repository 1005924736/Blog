﻿using Blog.Entities.Dtos;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.IServices
{
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 插入数据（适用于id自动增长）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回主键ID</returns>
        OperateResult InsertScalar(TEntity entity);

        /// <summary>
        /// 插入数据（适用于id自动增长）并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回主键ID</returns>
        OperateResult InsertScalarRemoveCache(TEntity entity);

        /// <summary>
        /// 插入数据（适用于id自动增长）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperateResult> InsertScalarAsync(TEntity entity);

        /// <summary>
        /// 插入数据（适用于id自动增长）并删除缓存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<OperateResult> InsertScalarRemoveCacheAsync(TEntity entity);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回是否插入成功</returns>
        OperateResult Insert(TEntity entity);

        /// <summary>
        /// 插入数据并清除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回是否插入成功</returns>
        OperateResult InsertRemoveCache(TEntity entity);

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回受影响行数</returns>
        Task<OperateResult> InsertAsync(TEntity entity);

        /// <summary>
        /// 插入数据并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>返回受影响行数</returns>
        Task<OperateResult> InsertRemoveCacheAsync(TEntity entity);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns></returns>
        OperateResult Insert(List<TEntity> entities);

        /// <summary>
        /// 批量添加并删除缓存
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns></returns>
        OperateResult InsertRemoveCache(List<TEntity> entities);

        /// <summary>
        /// 批量添加（异步）
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>受影响的行数</returns>
        Task<OperateResult> InsertAsync(List<TEntity> entities);

        /// <summary>
        /// 批量添加（异步）并删除缓存
        /// </summary>
        /// <param name="entities">实体对象集合</param>
        /// <returns>受影响的行数</returns>
        Task<OperateResult> InsertRemoveCacheAsync(List<TEntity> entities);

        /// <summary>
        /// 通过主键修改（包含是否需要将null值字段提交到数据库）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        OperateResult Update(TEntity entity, bool isNoUpdateNull = false);

        /// <summary>
        /// 通过主键修改（包含是否需要将null值字段提交到数据库）并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        OperateResult UpdateRemoveCache(TEntity entity, bool isNoUpdateNull = false);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        Task<OperateResult> UpdateAsync(TEntity entity, bool isNoUpdateNull = false);

        /// <summary>
        /// 通过主键修改（包含是否需要将null值字段提交到数据库）异步，并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="isNoUpdateNull">是否排除NULL值字段更新</param>
        /// <returns></returns>
        Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, bool isNoUpdateNull = false);

        /// <summary>
        /// 修改（更新实体部分字段）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        OperateResult Update(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 修改（更新实体部分字段）并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        OperateResult UpdateRemoveCache(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 修改（更新实体部分字段）
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        Task<OperateResult> UpdateAsync(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 修改（更新实体部分字段）异步，并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="ignoreColumns">忽略字段（不更新字段）</param>
        /// <returns></returns>
        Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 通过条件更新(不更新忽略字段)
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        OperateResult Update(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 通过条件更新(不更新忽略字段),并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        OperateResult UpdateRemoveCache(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 通过条件更新(不更新忽略字段)异步
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        Task<OperateResult> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 通过条件更新(不更新忽略字段)异步,并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <param name="ignoreColumns">忽略更新的字段</param>
        /// <returns></returns>
        Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> ignoreColumns);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        OperateResult Update(TEntity entity, Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 通过条件修改，并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        OperateResult UpdateRemoveCache(TEntity entity, Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">Lambda表达式</param>
        /// <returns></returns>
        Task<OperateResult> UpdateAsync(TEntity entity, Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        Task<OperateResult> UpdateRemoveCacheAsync(TEntity entity, Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 修改指定字段
        /// </summary>
        /// <param name="expression">Lambda表达式对象</param>
        /// <param name="condition">Lambda表达式条件</param>
        /// <returns></returns>
        OperateResult Update(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// 修改指定字段,并删除缓存
        /// </summary>
        /// <param name="expression">条件对象</param>
        /// <param name="condition">条件条件</param>
        /// <returns></returns>
        OperateResult UpdateRemoveCache(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// 修改指定字段（异步）
        /// </summary>
        /// <param name="expression">Lambda表达式对象</param>
        /// <param name="condition">Lambda表达式条件</param>
        /// <returns></returns>
        Task<OperateResult> UpdateAsync(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// 修改指定字段,并删除缓存
        /// </summary>
        /// <param name="expression">条件对象</param>
        /// <param name="condition">条件条件</param>
        /// <returns></returns>
        Task<OperateResult> UpdateRemoveCacheAsync(Expression<Func<TEntity, TEntity>> expression, Expression<Func<TEntity, bool>> condition);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        OperateResult Delete(dynamic keyValue);

        /// <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        OperateResult DeleteRemoveCache(dynamic keyValue);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<OperateResult> DeleteAsync(dynamic keyValue);

        /// <summary>
        /// 删除(异步)并删除缓存
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns></returns>
        Task<OperateResult> DeleteRemoveCacheAsync(dynamic keyValue);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        OperateResult Delete(TEntity entity);

        // <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>是否删除成功</returns>
        OperateResult DeleteRemoveCache(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        Task<OperateResult> DeleteAsync(TEntity entity);

        // <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>是否删除成功</returns>
        Task<OperateResult> DeleteRemoveCacheAsync(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        OperateResult Delete(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 删除并删除缓存
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        OperateResult DeleteRemoveCache(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        Task<OperateResult> DeleteAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 删除（异步）并删除缓存
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        Task<OperateResult> DeleteRemoveCacheAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns>是否删除成功</returns>
        OperateResult Delete(List<dynamic> keys);

        /// <summary>
        /// 批量删除并删除缓存
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        OperateResult DeleteRemoveCache(List<dynamic> keys);

        // <summary>
        /// 批量删除
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        Task<OperateResult> DeleteAsync(List<dynamic> keys);

        /// <summary>
        /// 批量删除（异步）并删除缓存
        /// </summary>
        /// <param name="keys">主键集合</param>
        /// <returns></returns>
        Task<OperateResult> DeleteRemoveCacheAsync(List<dynamic> keys);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue">主键</param>
        /// <returns>返回实体</returns>
        TEntity FindEntity(object keyValue);

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns>返回实体</returns>
        TEntity FindEntity(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 根据条件获取实体
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns>返回实体</returns>
        Task<TEntity> FindEntityAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 获取所有集合
        /// </summary>
        /// <returns>集合</returns>
        List<TEntity> Queryable();

        /// <summary>
        /// 获取所有集合(缓存)
        /// </summary>
        /// <param name="s">缓存时间：秒</param>
        /// <returns></returns>
        List<TEntity> QueryableCache(int s = int.MaxValue);

        /// <summary>
        /// 获取所有集合
        /// </summary>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableAsync();

        /// <summary>
        /// 获取所有集合(缓存)
        /// </summary>
        /// <param name="s">缓存时间：秒</param>
        /// <returns></returns>
        Task<List<TEntity>> QueryableCacheAsync(int s = int.MaxValue);

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns>集合</returns>
        List<TEntity> Queryable(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 根据条件获取集合并加入缓存
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns></returns>
        List<TEntity> QueryableCache(Expression<Func<TEntity, bool>> expression, int s = int.MaxValue);

        /// <summary>
        /// 检查信息总条数
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        int QueryableCount(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 检查信息总条数
        /// </summary>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        Task<int> QueryableCountAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// 根据条件获取集合(缓存)
        /// </summary>
        /// <param name="expression">条件Lambda表达式</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableCacheAsync(Expression<Func<TEntity, bool>> expression, int s = int.MaxValue);

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <returns>集合</returns>
        List<TEntity> Queryable(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc);

        /// <summary>
        /// 根据条件获取集合(缓存)
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        List<TEntity> QueryableCache(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int s = int.MaxValue);

        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc);

        /// <summary>
        /// 根据条件获取集合(缓存)异步
        /// </summary>
        /// <param name="expression">条件Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableCacheAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int s = int.MaxValue);

        /// <summary>
        /// 根据条件获取指定条数集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <returns>集合</returns>
        List<TEntity> Queryable(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top);

        /// <summary>
        /// 根据条件获取指定条数集合(缓存)
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        List<TEntity> QueryableCache(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top, int s = int.MaxValue);

        /// <summary>
        /// 根据条件获取指定条数集合
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top);

        /// <summary>
        /// 根据条件获取指定条数集合(缓存)异步
        /// </summary>
        /// <param name="expression">Lambda表达式</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="top">前N条数据</param>
        /// <param name="s">缓存时间：秒</param>
        /// <returns>集合</returns>
        Task<List<TEntity>> QueryableCacheAsync(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int top, int s = int.MaxValue);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="orderby">排序</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>集合|总条数</returns>
        Tuple<List<TEntity>, int> QueryableByPage(Expression<Func<TEntity, bool>> expression, Expression<Func<TEntity, object>> orderby, bool isDesc, int pageIndex, int pageSize);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="expression">条件</param>
        /// <param name="orderby">多字段排序</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>集合|总条数</returns>
        Tuple<List<TEntity>, int> QueryableByPage(Expression<Func<TEntity, bool>> expression, Dictionary<Expression<Func<TEntity, object>>, OrderByType> orderby, int pageIndex, int pageSize);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="conditionals">查询条件</param>
        /// <param name="orderFileds">排序字段</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        Tuple<List<TEntity>, int> QueryableByPage(List<IConditionalModel> conditionals, string orderFileds, int pageIndex, int pageSize);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="model">分页查询实体</param>
        /// <returns></returns>
        PageResult<List<TEntity>> QueryableByPage(QueryDto model);
    }
}
